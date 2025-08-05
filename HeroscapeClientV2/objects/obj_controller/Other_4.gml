switch (room)
{
	case rm_connect:
		var _request = new Request(SERVER_ADDRESS+"/Heroscape/GetStatus", request_type.status_get, "GET", "");
	
		_request.Send();
		
		status = "Connecting...";
		break;
	
	case rm_browse:
		
	
		break;
}