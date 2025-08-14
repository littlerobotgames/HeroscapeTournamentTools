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
		var _entries = array_create(0);
		
		for (var i = 0; i < array_length(global.build_army.army_entries); i++)
		{
			var _entry = global.build_army.army_entries[i];
				
			array_push(_entries, { cardId: _entry.unit_id, amount: _entry.unit_amount });
		}
			
		var _data = {
			armyId: global.build_army.army_id,
			name: global.build_army.army_name,
			playerId: global.build_army.playerId,
			armyEntries: _entries
		};
			
		var _data_string = json_stringify(_data);
		var _request = new Request(SERVER_ADDRESS+"/Heroscape/UpdateArmy", request_type.army_save, "PATCH", _data_string);
		_request.AddHeader("Content-Type", "text/json");
		
		_request.Send();
	}
}