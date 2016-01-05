grammar Domain;

import CommonLexerRules;

prog: stat+
	;

stat: expr NEWLINE			# printExpr 
	| ID '=' expr NEWLINE	# assign 
	| NEWLINE				# blank 
	;
expr: expr op=(MUL|DIV) expr	# Muldiv
	| expr op=(ADD|SUB) expr	# AddSub 
	| INT						# int 
	| ID						# id 
	| OBR expr CBR				# parens 
	;