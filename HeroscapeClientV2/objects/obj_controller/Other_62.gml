var _id = async_load[? "id"];
var _status = async_load[? "status"];
var _result = async_load[? "result"];
var _url = async_load[? "url"];
var _http_status = async_load[? "http_status"];

show_debug_message($"[{_id}] Got a message from the server");

switch (_status)
{
	case 0:
		//request finished
		var _request = request_find(_id);
		
		show_debug_message(_request);
		
		if _request != -1
		{
			switch(_request.type)
			{
				case request_type.status_get:
					show_debug_message($"Got a status_get from the server [{_http_status}]");
					
					var _temp_request = new Request(SERVER_ADDRESS+"/Heroscape/GetDatabaseVersion", request_type.database_version, "GET", "");
					_temp_request.Send();
					
					break;
					
				case request_type.database_version:
					show_debug_message($"Got a database_version from the server [{_http_status}]");
					
					if !file_exists("card_database.json")
					{
						_temp_request = new Request(SERVER_ADDRESS+"/Heroscape/GetCardDatabase", request_type.database_get_cards, "GET", "");
						_temp_request.Send();
						
						_temp_request = new Request(SERVER_ADDRESS+"/Heroscape/GetSetDatabase", request_type.database_get_sets, "GET", "");
						_temp_request.Send();
					}
					else
					{
						var _file = file_text_open_read("card_database.json");
	
						var _data = file_text_read_string(_file);
	
						file_text_close(_file);
	
						global.card_database = json_parse(_data);
						
						room_goto(rm_browse);
					}
					
					show_debug_message(_result);
				
					break;
				
				case request_type.database_get_cards:
					show_debug_message($"Got a database_get_cards from the server [{_http_status}]");
				
					show_debug_message(_result);
					
					var _file = file_text_open_write("card_database.json");
					file_text_write_string(_file, _result);
					
					file_text_close(_file);
					
					room_goto(rm_browse);
					break;
				
				case request_type.database_get_sets:
					show_debug_message($"Got a database_get_sets from the server [{_http_status}]");
					
					_file = file_text_open_write("set_database.json");
					file_text_write_string(_file, _result);
					
					file_text_close(_file);
					
					break;
			}
			
			request_remove(_id);
			
		}
		
		break;
	case 1:
		//request downloading
		var _length = async_load[? "contentLength"];
		var _downloaded = async_load[? "sizeDownloaded"];
		
		show_debug_message($"{_downloaded}/{_length}");
		
		break;
}