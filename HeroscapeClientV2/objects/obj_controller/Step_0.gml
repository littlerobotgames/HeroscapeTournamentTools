switch (room)
{
	case rm_connect:
		anim_frame++;
		break;
	case rm_login:
		if keyboard_check_pressed(vk_enter)
		{
			Login();
		}
		
		if keyboard_check_pressed(vk_tab)
		{
			if textbox_username.typing
			{
				textbox_password.typing = true;
				textbox_username.typing = false
				
				keyboard_string = "";
			}
		}
		break;
}