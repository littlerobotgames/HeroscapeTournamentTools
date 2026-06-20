function Team(_teamname, _playernames) constructor
{
	teamname = _teamname;
	players = _playernames;
	players_faced = ds_list_create();
	maps_played = ds_list_create();
}