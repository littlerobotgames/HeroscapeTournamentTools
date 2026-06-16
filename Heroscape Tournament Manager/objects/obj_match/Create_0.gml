/// @description Insert description here
// You can write your code in this editor
match_ahead = noone;
branches = ds_list_create();
ds_list_add(branches, new Branch());
ds_list_add(branches, new Branch());

battlefield = -1;

match_round = 1;
finished = false;
winner = -1;

spot = 0;

function create_match(_num)
{
if branches[|_num].match_previous = noone
	{
	var _dis = 500 / match_round;
	var _dis_half = _dis / 2;
	
	with (instance_create_layer(x+350, y-_dis_half+(_num*_dis), "Instances", obj_match))
		{
		other.branches[|_num].match_previous = self.id;
		
		match_ahead = other.id;
		
		match_round = other.match_round+1;
		
		spot = other.spot * 2 + _num;		
		}
	}
}
function conclude_match(_num)
{
winner = branches[|_num].p_id;
finished = true;
}

function undo_match()
{
winner = -1;
finished = false;
}
function update_players()
{
if branches[|0].p_id = -1
	{
	if branches[|0].match_previous != noone
		{
		if branches[|0].match_previous.winner != -1
			{
			branches[|0].p_id = branches[|0].match_previous.winner;
			}
		}
	}
if branches[|1].p_id = -1
	{
	if branches[|1].match_previous != noone
		{
		if branches[|1].match_previous.winner != -1
			{
			branches[|1].p_id = branches[|1].match_previous.winner;
			}
		}
	}
play_matches_create();
}