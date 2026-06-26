global.players = ds_list_create();

randomize();

ds_list_add(global.players, new Team("Forged in Flame", "Alex and Nicole"));
ds_list_add(global.players, new Team("Blood and Bones", "Zach and Connor"));
ds_list_add(global.players, new Team("Biblically Accurate Angels", "Ethan and Hannah"));
ds_list_add(global.players, new Team("B.U.T.T.S.", "Matt and Megan"));
ds_list_add(global.players, new Team("Valiant Vikings", "Jake and Chris"));
ds_list_add(global.players, new Team("The Gongs", "Dylan and Tyler"));

round_current = 0;
round_max = 3

hold_current = 0;

function NewRound()
{
	show_debug_message($"~~~~~~~ {round_current} Round Start Code ~~~~~~~");
	var _maps = ds_list_create();
	var _players_to_place = ds_list_create();
	
	for (var i = 0; i < ds_list_size(global.players); i++)
	{
		ds_list_add(_players_to_place, i);
	}
	
	with(obj_map)
	{	
		ds_list_add(_maps, id);
		team_one = -1;
		team_two = -1;
	}
	
	ds_list_shuffle(_maps);
	
	for (var i = 0; i < 3; i++)
	{
		show_debug_message($"~~~~ MAP {i} ~~~~");
		with(_maps[|i])
		{
			show_debug_message(map_name);
			
			var _random_team_index = irandom(ds_list_size(_players_to_place) - 1);
			var _main_index = _players_to_place[|_random_team_index];
			var _random_team = global.players[|_main_index];
		
			var _tries = 0;
			
			while(ds_list_find_index(_random_team.maps_played, id) != -1)
			{
				show_debug_message($"Team one while loop [Try {_tries}]");
				
				_random_team_index = irandom(ds_list_size(_players_to_place) - 1);
				_main_index = _players_to_place[|_random_team_index];
				_random_team = global.players[|_main_index];
				
				_tries++;
					
				if _tries = 20
				{
					return false;
				}
			}
			
			team_one = _main_index;
			
			ds_list_delete(_players_to_place, _random_team_index);
			
			//Find team two
			
			_tries = 0;
			
			_random_team_index = irandom(ds_list_size(_players_to_place) - 1);
			_main_index = _players_to_place[|_random_team_index];
			_random_team = global.players[|_main_index];
		
			while(ds_list_find_index(_random_team.maps_played, id) != -1 or ds_list_find_index(global.players[|team_one].players_faced, _main_index) != -1)
			{
				show_debug_message($"Team two while loop [Try {_tries}]");
				_random_team_index = irandom(ds_list_size(_players_to_place) - 1);
				_main_index = _players_to_place[|_random_team_index];
				_random_team = global.players[|_main_index];

				_tries++;
					
				if _tries = 20
				{
					return false;
				}
			}
			
			team_two = _main_index;
			
			ds_list_delete(_players_to_place, _random_team_index);
		}
	}
	
	return true;
}