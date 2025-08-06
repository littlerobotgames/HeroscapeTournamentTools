#macro MODE_BROWSE 0
#macro MODE_BUILD 1

unit_cards = ds_list_create();

var _grid_x = 0;
var _grid_y = 0;

card_width = 100;
card_height = 75;
card_spacing = 10;

spots_h = 5;

scrollbar_width = spots_h * (card_width + card_spacing) + card_spacing;
scrollbar_height = 575;

scroll_amount = 0;
scroll_amount_current = 0;
scroll_max = 0;
scroll_speed = 24;

mode = MODE_BROWSE;

x = room_width - 600;
y = room_height - 600;

for (var i = 0; i < array_length(global.card_database); i++)
{
	var _card_data = global.card_database[i];
	
	var _unit_card = new UnitCard(_card_data, card_width, card_height, _grid_x, _grid_y, card_spacing, self);
	
	if global.build_army != -1
	{
		for (var e = 0; e < array_length(global.build_army.army_entries); e++)
		{
			var _entry_data = global.build_army.army_entries[e];
			
			if _entry_data.unit_id = _unit_card.card_id
			{
				_unit_card.amount = _entry_data.unit_amount;
			}
		}
	}
	
	ds_list_add(unit_cards, _unit_card); 
	
	_grid_x++;
	
	if _grid_x = spots_h
	{
		_grid_y++;
		_grid_x = 0;
	}
}

my_surface = surface_create(scrollbar_width, scrollbar_height);

scroll_max = (_grid_y * (card_height + card_spacing) - scrollbar_height) + card_spacing;

click_scrolling = false;