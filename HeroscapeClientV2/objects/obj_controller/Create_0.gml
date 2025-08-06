#macro SERVER_ADDRESS "https://localhost:7000"

global.requests = ds_list_create();

global.card_database = array_create(0);

global.selected_card = -1;

global.player_data = -1;


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

armies_data = array_create(0);
global.build_army = -1;