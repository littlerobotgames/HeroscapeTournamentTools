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
	
	var _done = NewRound();
	
	while(!_done)
	{
		_done = NewRound();
	}
}