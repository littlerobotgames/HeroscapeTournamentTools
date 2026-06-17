if up
	{
	y = lerp(y, room_height-30, 0.2);
	
	if floor(y)=room_height-30
		{
		up = false;
		alarm[0]=120;
		}
	}
if down
	{
	y = lerp(y, room_height+30, 0.2);
	
	if floor(y)=room_height+30
		{
		instance_destroy();
		}
	}