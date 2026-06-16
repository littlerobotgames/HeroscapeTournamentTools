if global.use_mode = MODE_BRACKET
	{
	if global.participants > 0 and array_length(global.maps) > 0
		{
		show_debug_message("~~~~~ Starting Bracket Creation");
		global.bracket_winners_firstnode = bracket_create_winners();
		show_debug_message("~~~~~ Starting Participant Placement");
		bracket_place_participants();
		show_debug_message("~~~~~ Starting Bracket Rearrangement");
		bracket_rearrange();

		play_matches_create();
		}
	}