var _hover = point_in_rectangle(mouse_x, mouse_y, bbox_left, bbox_top, bbox_right, bbox_bottom);

if _hover
{
	image_index = 1;
}
else
{
	image_index = 0;
}

if mouse_check_button_pressed(mb_left)
{
	if _hover
	{
		global.build_army = new ArmyCard(
		{
		armyId: -1,
		name: "New Army",
		armyEntries: [],
		playerId: global.player_data.playerId
		}) ;
		room_goto(my_room);
	}
}