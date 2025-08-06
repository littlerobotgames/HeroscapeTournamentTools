switch (room)
{
	case rm_connect:
		anim_frame++;
		break;
	case rm_login:
		if keyboard_check_pressed(vk_enter)
		{
			var _login_struct = {
			email: textbox_username.text,
			password: textbox_password.text
			}
			
			var _login_string = json_stringify(_login_struct, true);
			
			var _request = new Request(SERVER_ADDRESS+"/Heroscape/PlayerLogin", request_type.player_login, "POST", _login_string);
			_request.AddHeader("Content-Type", "text/json");
			
			_request.Send();
			
			status = "Logging in...";
			room_goto(rm_connect);
		}
		break;
}