if room == rm_connect
{
	var _request = new Request(SERVER_ADDRESS+"/Heroscape/GetStatus", request_type.status_get, "GET", 0, "", function() {
		var _temp_request = new Request(SERVER_ADDRESS+"/Heroscape/GetCardDatabase", request_type.database_get_cards, "GET", 0, "", function() {});
		
		_temp_request.Send();
		
		room_goto(rm_login);
		});
	
	_request.Send();
}