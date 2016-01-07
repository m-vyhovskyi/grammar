lexer grammar CommonLexerRules;

STRING: '"' .*? '"';
ID : [a-zA-Z]+ ; // match identifiers 
LANGID: [a-zA-Z-]+;
INT : [0-9]+ ; // match integers 
WS : [ \r\n\t]+ -> skip ; // toss out whitespaces

MUL	:	'*';
DIV	:	'/';
ADD	:	'+';
SUB	:	'-';
OBR	:	'(';
CBR	:	')';

TERM:	';';