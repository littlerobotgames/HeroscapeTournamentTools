function database_cards_save()
{
}

function database_cards_load()
{
	var _file = file_text_open_read("card_database.json");
	
	var _data = file_text_read_string(_file);
	
	file_text_close(_file);
	
	global.card_database = json_parse(_data);
}

function database_sets_load()
{
	
}

function file_locals_save()
{
	ini_open("settings.ini");
	
	ini_write_string("user", "email", global.saved_email);
	ini_write_real("data", "version", global.database_version);
	ini_write_real("data", "patch", global.database_patch);
	
	ini_close();
}

function file_locals_load()
{
	ini_open("settings.ini");
	
	global.saved_email = ini_read_string("user", "email", "");
	global.database_version = ini_read_real("data", "version", 1);
	global.database_patch = ini_read_real("data", "patch", 0);
	
	ini_close();
}