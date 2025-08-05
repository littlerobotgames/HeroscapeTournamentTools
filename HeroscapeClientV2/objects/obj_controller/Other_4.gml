switch (room)
{
	case rm_connect:
		
		if display_get_width() > 1920
		{
			var _window_width = display_get_width() * 0.75;
			var _window_height = (_window_width * 9) / 16;
		
			window_set_size(_window_width, _window_height);
			window_center();
		
			surface_resize(application_surface, _window_width, _window_height);
		}
		
		var _request = new Request(SERVER_ADDRESS+"/Heroscape/GetStatus", request_type.status_get, "GET", "");
	
		_request.Send();
		
		status = "Connecting...";
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
}