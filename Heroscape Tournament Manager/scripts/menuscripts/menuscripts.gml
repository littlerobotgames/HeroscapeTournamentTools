// Script assets have changed for v2.3.0 see
// https://help.yoyogames.com/hc/en-us/articles/360005277377 for more information
function player_cards_update()
{
instance_destroy(obj_player_editor);

var line = 1;
var row = 1;

for (var p = 0; p < array_length(global.playerlist); p++)
	{
	with(instance_create_layer(row*300, line*400, "Instances", obj_player_editor))
		{
		p_id = p;
		my_image = sprite_add($"tourneys/{global.tourney_file}/player_icons/{global.playerlist[p].icon}", 1, false, false, 0, 0);
		}
	row++;
	if row=9
		{
		row = 1;
		line++;
		}
	}
instance_create_layer(row*300, line*400, "Instances", obj_pcard_new);
}

function map_cards_update()
{
instance_destroy(obj_map_editor);

var line = 1;
var row = 1;
for (var p = 0; p < array_length(global.maps); p++)
	{
	with(instance_create_layer(row*300, line*400, "Instances", obj_map_editor))
		{
		m_id = p;
		my_image = sprite_add("map_icons/"+global.maps[p].image+".png", 1, false, false, 0, 0);
		}
	row++;
	if row=9
		{
		row = 1;
		line++;
		}
	}
instance_create_layer(row*300, line*400, "Instances", obj_mcard_new);
}

function popup_create(poptext)
{
with(instance_create_layer(0,0,"Instances", obj_message))
	{
	text = poptext;
	}
}