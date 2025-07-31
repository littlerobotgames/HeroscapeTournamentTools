unit_cards = ds_list_create();

var _grid_x = 0;
var _grid_y = 0;

for (var i = 0; i < array_length(global.card_database); i++)
{
	var _card_data = global.card_database[i];
	
	with (instance_create_layer(612 + (i * 115), 60, "Cards", obj_unit_card))
	{
		card_id = _card_data.id;
		card_name = _card_data.name;
		card_general = _card_data.general;
		
		grid_x = _grid_x;
		grid_y = _grid_y;
	}
	
	_grid_x++;
	
	if _grid_x = 5
	{
		_grid_y++;
		_grid_x = 0;
	}
}