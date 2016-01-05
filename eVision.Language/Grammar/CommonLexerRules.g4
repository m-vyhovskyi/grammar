lexer grammar CommonLexerRules;

ID : [a-zA-Z]+ ; // match identifiers 
INT : [0-9]+ ; // match integers 
NEWLINE:'\r'?'\n' ; // return newlines to parser (end-statement signal) 
WS : ' '+ -> skip ; // toss out whitespaces

MUL	:	'*';
DIV	:	'/';
ADD	:	'+';
SUB	:	'-';
OBR	:	'(';
CBR	:	')';

TERM:	';';