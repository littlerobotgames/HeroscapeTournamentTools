var _id = async_load[? "id"];
var _status = async_load[? "status"];
var _result = async_load[? "result"];
var _url = async_load[? "url"];
var _http_status = async_load[? "http_status"];

switch (_status)
{
	case 0:
		//request finished
		var _request = request_find(_id);
		
		if _request != -1
		{
			switch(_request.type)
			{
				case request_type.status_get:
					show_debug_message($"Got a status_get from the server [{_http_status}]");
					
					_request.Success();
					
					break;
				case request_type.database_version:
					show_debug_message($"Got a database_version from the server [{_http_status}]");
				
					break;
				
				case request_type.database_get_cards:
					show_debug_message($"Got a database_get_cards from the server [{_http_status}]");
				
					show_debug_message(_result);
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