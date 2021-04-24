#include "hwid.hpp"
#include "../crypto/xorstr.hpp"
#include "../contrib/okdshin/picosha2.h"
#include "smbios.hpp"

using namespace ls;
using namespace smbios;
using json = nlohmann::json;

std::string& ltrim(std::string& str, const std::string& chars = "\t\n\v\f\r ")
{
	str.erase(0, str.find_first_not_of(chars));
	return str;
}

std::string& rtrim(std::string& str, const std::string& chars = "\t\n\v\f\r ")
{
	str.erase(str.find_last_not_of(chars) + 1);
	return str;
}

std::string& trim(std::string& str, const std::string& chars = "\t\n\v\f\r ")
{
	return ltrim(rtrim(str, chars), chars);
}

void remove_substrs(std::string& s, const std::string& p)
{
	const auto n = p.length();
	for (auto i = s.find(p);
		i != std::string::npos;
		i = s.find(p))
		s.erase(i, n);
}

std::string hwid::get_super_secret_info()
{
	// Query size of SMBIOS data.
	const DWORD smbios_data_size = GetSystemFirmwareTable('RSMB', 0, nullptr, 0);

	// Allocate memory for SMBIOS data
	auto* const heap_handle = GetProcessHeap();
	auto* const smbios_data = static_cast<raw_smbios_data*>(HeapAlloc(heap_handle, 0,
		static_cast<size_t>(smbios_data_size)));
	if (!smbios_data)
	{
		return 0;
	}

	// Retrieve the SMBIOS table
	const DWORD bytes_written = GetSystemFirmwareTable('RSMB', 0, smbios_data, smbios_data_size);
	if (bytes_written != smbios_data_size)
	{
		return 0;
	}

	// Process the SMBIOS data and free the memory under an exit label
	parser meta;
	const BYTE* buff = smbios_data->smbios_table_data;
	const auto buff_size = static_cast<size_t>(smbios_data_size);

	meta.feed(buff, buff_size);

	std::string hardware;
	json json_hwid;

	for (auto& header : meta.headers)
	{
		string_array_t strings;
		parser::extract_strings(header, strings);

		switch (header->type)
		{
		case types::baseboard_info:
		{
			auto* const x = reinterpret_cast<baseboard_info*>(header);

			if (x->length == 0)
				break;

			json_hwid["baseboard_info"][header->handle]["manufacturer_name"] = strings[x->manufacturer_name];
			json_hwid["baseboard_info"][header->handle]["product_name"] = strings[x->product_name];
		}
		break;

		case types::bios_info:
		{
			auto* const x = reinterpret_cast<bios_info*>(header);

			if (x->length == 0)
				break;

			json_hwid["bios_info"][header->handle]["vendor"] = strings[x->vendor];
			json_hwid["bios_info"][header->handle]["version"] = strings[x->version];
			json_hwid["bios_info"][header->handle]["release_date"] = strings[x->release_date];
		}
		break;


		case types::processor_info:
		{
			auto* const x = reinterpret_cast<proc_info*>(header);

			if (x->length == 0)
				break;

			json_hwid["processor_info"][header->handle]["socket_designation"] = strings[x->socket_designation];
			json_hwid["processor_info"][header->handle]["manufacturer"] = strings[x->manufacturer];
			json_hwid["processor_info"][header->handle]["version"] = strings[x->version];
			json_hwid["processor_info"][header->handle]["id"] = std::to_string(static_cast<long>(x->id));
			json_hwid["processor_info"][header->handle]["cores"] = std::to_string(static_cast<long>(x->cores));
			json_hwid["processor_info"][header->handle]["threads"] = std::to_string(static_cast<long>(x->threads));
		}
		break;

		default:;
		}
	}

	HeapFree(heap_handle, 0, smbios_data);


	std::string hwid;
	std::string hwid_sha256;

	hwid.append(json_hwid.dump());

	std::string pattern = "null,";

	remove_substrs(hwid, pattern);

	picosha2::hash256_hex_string(hwid, hwid_sha256);

    return hwid_sha256;
}
