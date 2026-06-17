// Script assets have changed for v2.3.0 see
// https://help.yoyogames.com/hc/en-us/articles/360005277377 for more information
function bracket_create_winners()
{
	instance_destroy(obj_match);
	
	max_nodes = 2;
	dirs = ds_list_create();
	ds_list_set(dirs, 0, 0);
	
	first_match = instance_create_layer(600, room_height/2, "Instances", obj_match);
	
	var empty_nodes = bracket_node_count_empty();
	
	//loop to add matches
	var counter = 0;
	while(empty_nodes < global.participants)
		{
		show_debug_message("~~~ empty_nodes ("+string(empty_nodes)+") < participants ("+string(global.participants)+")");
		if empty_nodes = max_nodes
			{
			max_nodes *= 2;
			show_debug_message("Multiplied max_nodes by 2: "+string(max_nodes));
			ds_list_add(dirs, 0);
			
			for (var i = 0; i < ds_list_size(dirs); i++)
				{
				dirs[|i]=0;
				}
			}
		bracket_match_from_directions();
		
		empty_nodes = bracket_node_count_empty();
		flip(0);
		show_debug_message("Flipped dirs, now it's "+print_list(dirs));
		
		counter++;
		
		if counter = 100
			{
			show_debug_message("Tried 100 times, whoops!");
			exit;
			}
		}
	return first_match;
}

function bracket_node_count_empty()
{
	var empty = 0;
	
	with (obj_match)
		{
		if branches[|0].match_previous = noone
			{
			empty++;
			}
		if branches[|1].match_previous = noone
			{
			empty++;
			}
		}
	
	return empty;
}

function Branch() constructor
{
	p_id = -1;
	match_previous = noone;
}

function flip(_index)
	{
	if dirs[|_index] = 0
		{
		dirs[|_index] = 1;
		}
	else if dirs[|_index] = 1
		{
		dirs[|_index] = 0;
		flip(_index+1);
		}
	}

function bracket_match_from_directions()
{
var current_match = first_match;
var current_direction_step = 0;
var counter = 0;

while (current_direction_step < ds_list_size(dirs))
	{
		var current_direction = dirs[|current_direction_step];
		
		if current_match.branches[|current_direction].match_previous != noone
			{
				current_match = current_match.branches[|current_direction].match_previous;
				current_direction_step++;
			}
		else
			{
				show_debug_message("Created match at: " + print_list(dirs));
				current_match.create_match(current_direction);
				return;
			}
	counter++;
	
	if counter = 100
		{
		return;
		}
	}
}

function print_list(_list)
{
	var str = "";
	
	for (var i = 0; i < ds_list_size(_list); i++)
		{
			str += string(_list[|i])+", ";
		}
	
	return str;
}

function bracket_place_participants()
{
var parts = array_create(global.participants, 0);
var matches = array_create(0);

with(obj_match)
	{
	if branches[|0].match_previous = noone or branches[|1].match_previous = noone
		{
		array_push(matches, id);
		}
	}
show_debug_message($"Added matches to list ({array_length(matches)})");

for (var i = 0; i < global.participants; i++)
	{
	parts[i] = i;
	}
show_debug_message($"Added players to list ({array_length(parts)})");

while (array_length(matches) > 0)
	{
	with (matches[0])
		{
		show_debug_message($"On match {id}"); 
		var is_by = (branches[|0].match_previous = noone and branches[|1].match_previous != noone) or 
			(branches[|0].match_previous != noone and branches[|1].match_previous = noone);
		
		var ran_index = irandom(array_length(parts)-1);
		var ran_player = parts[ran_index];
		
		if is_by
			{
			show_debug_message("* Is a by round *");
			var bys_left = players_toplace_countautos(parts);
			show_debug_message($"By players left to place: {bys_left}");
			
			if bys_left > 0
				{
				while(!global.playerlist[ran_player].autoby)
					{
					ran_index = irandom(array_length(parts)-1);
					ran_player = parts[ran_index];
					}
				}
			}
		else
			{
			show_debug_message("* Is not a by round *");
			
			while(global.playerlist[ran_player].autoby)
				{	
				ran_index = irandom(array_length(parts)-1);
				ran_player = parts[ran_index];
				}
			}
		
		if branches[|0].match_previous = noone and branches[|0].p_id = -1
			{
			branches[|0].p_id = ran_player;
			array_delete(parts, ran_index, 1);
			
			show_debug_message("Added player " + string(ran_player) + " to branch 0");
			show_debug_message("Parts list size now "+string(array_length(parts)));
			}
		
		else if branches[|1].match_previous = noone and branches[|1].p_id = -1
			{
			branches[|1].p_id = ran_player;
			array_delete(parts, ran_index, 1);
			
			show_debug_message("Added player " + string(ran_player) + " to branch 1");
			show_debug_message("Parts list size now "+string(array_length(parts)));
			}
		
		//Check if match is full
		if is_by
			{
			if branches[|0].match_previous = noone
				{
				if branches[|0].p_id != -1
					{
					array_delete(matches, 0, 1);
					}
				}
			else if branches[|1].match_previous = noone
				{
				if branches[|1].p_id != -1
					{
					array_delete(matches, 0, 1);
					}
				}
			}
		else
			{
			if branches[|0].p_id != -1 and branches[|1].p_id != -1
				{
				array_delete(matches, 0, 1);
				}
			}
		
		}
	}
}
function players_toplace_countautos(_list)
{
var total_by = 0;	
for (var i = 0; i < array_length(_list); i++)
	{
	if global.playerlist[_list[i]].autoby = true
		{
		total_by++;
		}
	}
return total_by;
}
function bracket_rearrange()
{	
	with(obj_match)
		{
		if match_round > global.max_round
			{
			global.max_round = match_round;
			}
		}
	
	var required_height = 180;
	
	for(var i = 2; i <= global.max_round; i++)
		{
		required_height *= 2;
		}
	show_debug_message($"Required Height = {required_height}");
	
	var matches = 1;
	for (var i = 1; i <= global.max_round; i++)
		{
		
		show_debug_message($"Matches this round = {matches}"); 
		var spacing = required_height/matches;
		show_debug_message($"Spacing = {spacing}");
		
		with(obj_match)
			{
			if match_round = i
				{
				y = (spacing*spot)+(spacing/2);
				}
			}
		
		matches*=2;
		}
	var diff = (room_height/2)-first_match.y;
	
	with(obj_match)
		{
		y+=diff;
		}
}
function play_matches_create()
{
instance_destroy(obj_match_play);

var matches = ds_list_create();

with(obj_match)
	{
	if finished = false
		{
		if branches[|0].p_id != -1 and branches[|1].p_id != -1
			{
			map_get_available();
			ds_list_add(matches, id);
			}
		}
	}

var spacing = room_width/ds_list_size(matches);

for (var i = 0; i < ds_list_size(matches); i++)
	{
	var match_id = matches[|i];
	with (instance_create_layer((spacing/2)+(spacing*i), (room_height/2), "Instances", obj_match_play))
		{
		match_obj = match_id;
		battlefield = match_id.battlefield;
		array_set(p_ids, 0, match_id.branches[|0].p_id);
		array_set(p_ids, 1, match_id.branches[|1].p_id);
		show_debug_message($"++ Created play match with: Battlefield {battlefield}, Player Id1 {p_ids[0]}, Player Id2 {p_ids[1]}");
		}
	}
}