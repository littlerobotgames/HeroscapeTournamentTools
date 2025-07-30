enum request_type
{
	status_get,
	database_version,
	database_get_cards,
}


function Request(_url, _type, _req_method, _headers, _data, _success_function) constructor
{
	url = _url;
	type = _type;
	req_method = _req_method;
	headers = _headers;
	data = _data;
	send_id = 0;
	Success = _success_function;
	
	Send = function()
	{
		ds_list_add(global.requests, self);
		
		send_id = http_request(url, req_method, headers, data);
		
		show_debug_message("Sent message to server");
	}
}

function request_find(_id)
{
	for (var i = 0; i < ds_list_size(global.requests); i++)
	{
		if global.requests[|i].send_id = _id
		{
			return global.requests[|i];
		}
	}
	
	return -1;
}

function request_remove(_id)
{
	for (var i = 0; i < ds_list_size(global.requests); i++)
	{
		if global.requests[|i].send_id = _id
		{
			ds_list_delete(global.requests, i);
			exit;
		}
	}
}