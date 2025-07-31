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