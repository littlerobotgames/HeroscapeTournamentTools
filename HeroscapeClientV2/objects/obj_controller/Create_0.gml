#macro SERVER_ADDRESS "https://localhost:7000"

global.requests = ds_list_create();

global.card_database = array_create(0);

global.selected_card = -1;

global.player_data = -1;

global.database_version = 0;
global.database_patch = 0;
global.saved_email = "";

file_locals_load();


global.general_data = ds_list_create();
ds_list_add(global.general_data, new GeneralData("Jandar",   make_color_rgb(172, 226, 247), c_white));
ds_list_add(global.general_data, new GeneralData("Einar",    make_color_rgb(222, 184, 122), c_white));
ds_list_add(global.general_data, new GeneralData("Ullar",    make_color_rgb(96, 153, 91),   c_white));
ds_list_add(global.general_data, new GeneralData("Vydar",    make_color_rgb(149, 149, 172), c_white));
ds_list_add(global.general_data, new GeneralData("Utgar",    make_color_rgb(178, 89, 92),   c_white));
ds_list_add(global.general_data, new GeneralData("Marvel",   make_color_rgb(238, 71, 77),   c_white));
ds_list_add(global.general_data, new GeneralData("Aquilla",  make_color_rgb(99, 53, 206),  c_white));
ds_list_add(global.general_data, new GeneralData("Valkrill", make_color_rgb(171, 164, 68), c_white));
ds_list_add(global.general_data, new GeneralData("Revna",    make_color_rgb(205, 205, 192), c_white));

error = "";
status = "";
anim_frame = 0;

textbox_username = noone;
textbox_password = noone;

textbox_army_name = noone;

armies_data = array_create(0);
global.build_army = -1;

function Login()
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