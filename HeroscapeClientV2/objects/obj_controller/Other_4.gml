switch (room)
{
	case rm_connect:
		
		
		break;
	
	case rm_browse:
		
	
		break;
	
	case rm_login:
		with(instance_create_layer(room_width / 2, 250, "Instances", obj_textbox))
		{
			other.textbox_username = self;
			reminder_text = "email";
		}
		with(instance_create_layer(room_width / 2, 300, "Instances", obj_textbox))
		{
			other.textbox_password = self;
			reminder_text = "password";
			hidden = true;
		}
		break;
	
	case rm_build_menu:
		var _request = new Request(SERVER_ADDRESS+"/Heroscape/GetPlayerArmies", request_type.get_player_armies, "GET", "");
		_request.AddHeader("playerId", string(global.player_data.id));
		
		_request.Send();
		break;
}