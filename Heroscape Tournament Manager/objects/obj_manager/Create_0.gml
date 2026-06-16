/// @description Insert description here
// You can write your code in this editor
#macro COLOR_BACKGROUND make_color_rgb(202, 202, 202)

#macro LEVEL_NOVICE 0
#macro LEVEL_ROOKIE 1
#macro LEVEL_INTERMEDIATE 2
#macro LEVEL_EXPERT 3

#macro MODE_PARTICPANTS 0
#macro MODE_MAPS 1
#macro MODE_BRACKET 2
#macro MODE_PLAY 3

randomize();

global.playerlist = array_create(0);
global.maps = array_create(0);

global.max_round = 1;
global.use_mode = MODE_PARTICPANTS;

global.level_names = array_create(4, "");
global.level_names[LEVEL_NOVICE] = "Novice";
global.level_names[LEVEL_ROOKIE] = "Rookie";
global.level_names[LEVEL_INTERMEDIATE] = "Intermediate";
global.level_names[LEVEL_EXPERT] = "Expert";

global.tournament_name = "Heroscape Singles Tournament 2024";
global.tourney_file = "HeroscapeFall2024";

global.current_play_round = 1;

if file_exists($"{working_directory}/tourneys/{global.tourney_file}/players.json")
	{
	load_players();
	}

global.participants = array_length(global.playerlist);

if file_exists($"{working_directory}/tourneys/{global.tourney_file}/maps.json")
	{
	load_maps();
	}
if global.participants > 0 and array_length(global.maps) > 0
	{
	show_debug_message("~~~~~ Starting Bracket Creation");
	global.bracket_winners_firstnode = bracket_create_winners();
	show_debug_message("~~~~~ Starting Participant Placement");
	bracket_place_participants();
	show_debug_message("~~~~~ Starting Bracket Rearrangement");
	bracket_rearrange();

	play_matches_create();
	}

player_cards_update();
map_cards_update();