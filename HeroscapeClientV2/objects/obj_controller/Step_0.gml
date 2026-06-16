switch (room)
{
	case rm_connect:
		anim_frame++;
		break;
	case rm_login:
		if keyboard_check_pressed(vk_enter)
		{
			global.saved_email = textbox_username.text;
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
	case rm_build:
		global.build_army.army_name = textbox_army_name.text;
		break;
}