grammar Domain;

import CommonLexerRules;

domain: domainDecl define+ ;

domainDecl: 'domain' ID;

define: defineDescriptor;

basedOn: 'based' 'on' ID;

defineDescriptor: 'define' 'descriptor' ID basedOn? 'with' descriptorBody # defDescriptor
				;

descriptorBody: descriptorItem+ ;

descriptorItem	: 'item' ID descriptorWith?  #defDescriptorItem						
				; 

descriptorWith	: 'with' (rank? | translation*)
				;

translation		: 'translation' translationRule*
				;

translationRule	: 'for' LANGID 'as' STRING
				;

rank: 'rank' 'as' INT;

