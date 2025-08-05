#macro SERVER_ADDRESS "https://localhost:7000"

global.requests = ds_list_create();

global.card_database = array_create(0);

global.selected_card = -1;


global.general_data = ds_list_create();
ds_list_add(global.general_data, new GeneralData("Jandar", c_blue, c_white));
ds_list_add(global.general_data, new GeneralData("Einar", make_color_rgb(210, 180, 140) , c_white));
ds_list_add(global.general_data, new GeneralData("Ullar", c_green, c_white));
ds_list_add(global.general_data, new GeneralData("Vydar", c_gray, c_white));
ds_list_add(global.general_data, new GeneralData("Utgar", c_maroon, c_white));
ds_list_add(global.general_data, new GeneralData("Marvel", c_purple, c_white));
ds_list_add(global.general_data, new GeneralData("Aquilla", make_color_rgb(99, 53, 206), c_white));

error = "";
status = "";
anim_frame = 0;