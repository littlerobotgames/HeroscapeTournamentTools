function unit_find(_unit_id)
{
	var _size = array_length(global.card_database);
	
	for (var i = 0; i < _size; i++)
	{
		var _unit = global.card_database[i];
		
		if _unit.id = _unit_id
		{
			return _unit;
		}
	}
	
	return noone;
}

function army_total_points(_armyEntries)
{
	var _points = 0;
	var _size = array_length(global.card_database);
	
	for (var e = 0; e < array_length(_armyEntries); e++)
	{
		var _entry = _armyEntries[e];
	
		for (var i = 0; i < _size; i++)
		{
			var _unit_data = global.card_database[i];
		
			if _unit_data.id = _entry.cardId
			{
				_points += _unit_data.points * _entry.amount;
			}
		}
	}
	
	return _points;
}

function army_total_hexes(_armyEntries)
{
	var _hexes = 0;
	var _size = array_length(global.card_database);
	
	for (var e = 0; e < array_length(_armyEntries); e++)
	{
		var _entry = _armyEntries[e];
	
		for (var i = 0; i < _size; i++)
		{
			var _unit_data = global.card_database[i];
		
			if _unit_data.id = _entry.cardId
			{
				_hexes += _unit_data.hex_per * _unit_data.figures * _entry.amount;
			}
		}
	}
	
	return _hexes;
}