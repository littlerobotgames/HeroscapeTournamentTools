// Script assets have changed for v2.3.0 see
// https://help.yoyogames.com/hc/en-us/articles/360005277377 for more information
function saveall()
{
save_players();
save_maps();

ini_open($"{working_directory}/tourneys/{global.tourney_file}/tourney_info.ini");
ini_write_string("tourneyInfo", "name", global.tournament_name);
ini_close();

ini_open($"{working_directory}/programData.ini");
ini_write_string("settings", "lastOpened", $"{global.tourney_file}");
ini_close();

popup_create("All Files Saved!");
show_debug_message("All files saved!");
}

function save_players()
{
players_string = json_stringify(global.playerlist);
var p_file = file_text_open_write($"{working_directory}/tourneys/{global.tourney_file}/players.json");
file_text_write_string(p_file, players_string);
file_text_close(p_file);
}

function save_maps()
{
maps_string = json_stringify(global.maps);
var m_file = file_text_open_write($"{working_directory}/tourneys/{global.tourney_file}/maps.json");
file_text_write_string(m_file, maps_string);
file_text_close(m_file);
}

function load_players()
{
var file = file_text_open_read($"{working_directory}/tourneys/{global.tourney_file}/players.json");
var players_string = file_text_read_string(file);
file_text_close(file);
global.playerlist = json_parse(players_string);
show_debug_message("** Loaded players from file **");

players_get_icons();
}

function load_maps()
{
var file = file_text_open_read($"{working_directory}/tourneys/{global.tourney_file}/maps.json");
var maps_string = file_text_read_string(file);
file_text_close(file);
global.maps = json_parse(maps_string);
show_debug_message("** Loaded maps from file **");

maps_get_sprites();
}