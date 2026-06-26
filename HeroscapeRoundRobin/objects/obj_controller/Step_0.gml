if keyboard_check(vk_space)
{
	if round_current < round_max
	{
		hold_current++;
	}
}
else
{
	hold_current = 0;
}

if hold_current >= 90
{	
	round_current++;
	hold_current = 0;
	
	with(obj_map)
	{
		if team_one != -1 and team_two != -1
		{
			ds_list_add(global.players[|team_one].maps_played, id);
			ds_list_add(global.players[|team_two].maps_played, id);
			
			ds_list_add(global.players[|team_one].players_faced, team_two);
			ds_list_add(global.players[|team_two].players_faced, team_one);
		}
	}
	
	var _done = NewRound();
	
	while(!_done)
	{
		_done = NewRound();
	}
}