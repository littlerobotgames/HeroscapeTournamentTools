enum request_type
{
	status_get,
	database_version,
	database_get_cards,
	database_get_sets,
}


function Request(_url, _type, _req_method, _data) constructor
{
	url = _url;
	type = _type;
	req_method = _req_method;
	headers = ds_map_create();
	data = _data;
	send_id = 0;
	
	Send = function()
	{
		ds_list_add(global.requests, self);
		
		send_id = http_request(url, req_method, headers, data);
		
		show_debug_message($"[{send_id}] Sent message to server");
	}
	
	AddHeader = function(_name, _value)
	{
		ds_map_add(headers, _name, _value);
	}
}

function request_find(_id)
{
	for (var i = 0; i < ds_list_size(global.requests); i++)
	{
		if global.requests[|i].send_id = _id
		{
			show_debug_message($"Found request [{_id}]");
			return global.requests[|i];
		}
	}
	
	show_debug_message($"Failed to find request [{_id}]");
	
	return -1;
}

function request_remove(_id)
{
	for (var i = 0; i < ds_list_size(global.requests); i++)
	{
		if global.requests[|i].send_id = _id
		{
			show_debug_message($"XXX Destroyed request [{global.requests[|i].send_id}]");
			
			ds_list_delete(global.requests, i);
			return true;
		}
	}
	
	return false;
}