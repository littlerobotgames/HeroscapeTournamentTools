// Script assets have changed for v2.3.0 see
// https://help.yoyogames.com/hc/en-us/articles/360005277377 for more information
function Map(_name, _image, _final = false) constructor
{
	name = _name;
	image = _image;
	final = _final;
	image_sprite = -1;
}
function maps_place()
{
var temp_maps = ds_list_create();

for (var i = global.max_round; i > 0; i--)
	{
	ds_list_clear(temp_maps);
	show_debug_message($"Round {i}");
	//Add maps possible to use
	show_debug_message("Adding maps to use");
	for (var m = 0; m < array_length(global.maps); m++)
		{
		if i = 1
			{
			if global.maps[m].final
				{
				ds_list_add(temp_maps, m);
				}
			}
		else
			{
			if !global.maps[m].final
				{
				ds_list_add(temp_maps, m);
				}
			}
		}
	show_debug_message($"{ds_list_size(temp_maps)} maps to use"); 
	//Assign possible maps to matches
	
	with (obj_match)
		{
			if match_round = i
				{
				var ran_index = irandom(ds_list_size(temp_maps)-1);
				var chosen_map = temp_maps[|ran_index];
			
				var branch_0 = branches[|0].match_previous;
				var branch_1 = branches[|1].match_previous;
			
				if  branch_0 != noone and branch_1 != noone
				{
				show_debug_message("Both branches full");
					while (chosen_map = branch_0.battlefield or chosen_map = branch_1.battlefield)
						{
						ran_index = irandom(ds_list_size(temp_maps)-1);
						chosen_map = temp_maps[|ran_index];
						}
				}
				else if branches[|0].match_previous = noone and branches[|1].match_previous != noone
				{
					while (chosen_map = branch_1.battlefield)
						{
						ran_index = irandom(ds_list_size(temp_maps)-1);
						chosen_map = temp_maps[|ran_index];
						}
				}
				else if branches[|0].match_previous != noone and branches[|1].match_previous = noone
				{
					while (chosen_map = branch_0.battlefield)
						{
						ran_index = irandom(ds_list_size(temp_maps)-1);
						chosen_map = temp_maps[|ran_index];
						}
				}
			
				ds_list_delete(temp_maps, ran_index);
				battlefield = chosen_map;
				}
		}
	}
}
function draw_map(_map_id, _x, _y)
{
var _image = global.maps[_map_id].image_sprite;
var _name = global.maps[_map_id].name;

if _image!=-1
	{
	draw_sprite_stretched_ext(_image, 0, _x-30, _y-30, 64, 64, c_black, 0.8);
	draw_sprite_stretched(_image, 0, _x-32, _y-32, 64, 64);
	}
		
draw_set_halign(fa_center);
draw_set_valign(fa_middle);
draw_set_font(fnt_army);
	
draw_set_color(c_black);
draw_text(_x+2, _y+27, _name);
draw_set_color(c_white);
draw_text(_x, _y+25, _name);
}
function maps_get_sprites()
{
	for (var m = 0; m < array_length(global.maps); m++)
		{
		global.maps[m].image_sprite = sprite_add("map_icons/"+global.maps[m].image+".png", 1, false, false, 0, 0);
		}
}
function map_get_available()
{
show_debug_message("<<<<<<<< Starting new map set cycle >>>>>>>>");
var _maps = array_create(0);

for (var i = 0; i < array_length(global.maps); i++)
	{
	if global.maps[i].final
		{
		if match_round = 1
			{
			battlefield = i;
			}
		}
	else
		{
		array_push(_maps, global.maps[i].name);
		}
	}

if battlefield != -1
	{
	exit;
	}

show_maps_array(_maps);

var branch_0 = branches[|0].match_previous;
var branch_1 = branches[|1].match_previous;

//remove the two previous maps from possibilities
if branch_0 != noone
	{
	var _name = global.maps[branch_0.battlefield].name;
	
	var _del_index = map_find_index_fromname(_maps, _name);
	
	if _del_index != -1
		{
		show_debug_message($"Delete index {_del_index}");
		array_delete(_maps, _del_index, 1);
		
		show_maps_array(_maps);
		}
	}
if branch_1 != noone
	{
	var _name = global.maps[branch_1.battlefield].name;
	
	var _del_index = map_find_index_fromname(_maps, _name);
	
	if _del_index != -1
		{
		show_debug_message($"Delete index {_del_index}");
		array_delete(_maps, _del_index, 1);
		
		show_maps_array(_maps);
		}
	}
//remove all maps currently being played on from possibilities
with (obj_match)
	{
	if !finished and branches[|0].p_id != -1 and branches[|1].p_id != -1 and battlefield != -1
		{
		show_debug_message($"Valid match to find a map for (BF: {battlefield})");
		
		var _name = global.maps[battlefield].name;
		
		var _del_index = map_find_index_fromname(_maps, _name);
		
		show_debug_message($"Delete index: {_del_index}");
		
		if _del_index != -1
			{
			array_delete(_maps, _del_index, 1);
			
			show_debug_message($"Delete index {_del_index}");
			show_maps_array(_maps);
			}
		}
	}
var _ran_name = _maps[irandom_range(0, array_length(_maps)-1)];
show_debug_message($"!!!!!!!!! I chose {_ran_name} !!!!!!!!!!");
	
for (var i = 0; i < array_length(global.maps); i++)
	{
	if global.maps[i].name = _ran_name
		{
		battlefield = i;
		}
	}
}

function map_find_index_fromname(_array, _map_name)
{
for (var i = 0; i < array_length(_array); i++)
	{
	if _array[i] = _map_name
		{
		show_debug_message($"{_array[i]} = {_map_name}: return {i}");
		return i;
		}
	}
return -1;
}

function show_maps_array(_array)
{
show_debug_message("------ Available Maps: ------");

for (var i = 0; i < array_length(_array); i++)
	{
	show_debug_message($"	{_array[i]}");
	}

show_debug_message("-----------------------------");
}