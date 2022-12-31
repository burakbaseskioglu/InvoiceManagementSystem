ë
uC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.WebAPI\Controllers\ApartmentController.cs
	namespace 	#
InvoiceManagementSystem
 !
.! "
WebAPI" (
.( )
Controllers) 4
{ 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
public		 

class		 
ApartmentController		 $
:		% &

Controller		' 1
{

 
private 
readonly 
IApartmentBusiness +
_apartmentBusiness, >
;> ?
public 
ApartmentController "
(" #
IApartmentBusiness# 5
apartmentBusiness6 G
)G H
{ 	
_apartmentBusiness 
=  
apartmentBusiness! 2
;2 3
} 	
[ 	
HttpGet	 
( 
$str 
)  
]  !
public 
IActionResult 
GetApartmentByName /
(/ 0
string0 6
apartmentName7 D
)D E
{ 	
return 
Ok 
( 
_apartmentBusiness (
.( )
GetApartmentByName) ;
(; <
apartmentName< I
)I J
)J K
;K L
} 	
[ 	
HttpGet	 
( 
$str  
)  !
]! "
public 
IActionResult 
GetApartments *
(* +
)+ ,
{ 	
return 
Ok 
( 
_apartmentBusiness (
.( )
GetAll) /
(/ 0
)0 1
)1 2
;2 3
} 	
[ 	
HttpGet	 
( 
$str #
)# $
]$ %
public 
IActionResult 
GetApartmentById -
(- .
int. 1
apartmentId2 =
)= >
{   	
return!! 
Ok!! 
(!! 
_apartmentBusiness!! (
.!!( )
GetApartmentById!!) 9
(!!9 :
apartmentId!!: E
)!!E F
)!!F G
;!!G H
}"" 	
[$$ 	
HttpPost$$	 
($$ 
$str$$  
)$$  !
]$$! "
public%% 
IActionResult%% 
AddApartment%% )
(%%) *
ApartmentDto%%* 6
	apartment%%7 @
)%%@ A
{&& 	
return'' 
Ok'' 
('' 
_apartmentBusiness'' (
.''( )
Insert'') /
(''/ 0
	apartment''0 9
)''9 :
)'': ;
;''; <
}(( 	
[** 	
HttpPut**	 
(** 
$str** "
)**" #
]**# $
public++ 
IActionResult++ 
UpdateApartment++ ,
(++, -
ApartmentDto++- 9
	apartment++: C
)++C D
{,, 	
return-- 
Ok-- 
(-- 
_apartmentBusiness-- (
.--( )
Update--) /
(--/ 0
	apartment--0 9
)--9 :
)--: ;
;--; <
}.. 	
[00 	

HttpDelete00	 
(00 
$str00 %
)00% &
]00& '
public11 
IActionResult11 
DeleteApartment11 ,
(11, -
int11- 0
apartmentId111 <
)11< =
{22 	
return33 
Ok33 
(33 
_apartmentBusiness33 (
.33( )
Delete33) /
(33/ 0
apartmentId330 ;
)33; <
)33< =
;33= >
}44 	
};; 
}<< ‘
pC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.WebAPI\Controllers\DuesController.cs
	namespace 	#
InvoiceManagementSystem
 !
.! "
WebAPI" (
.( )
Controllers) 4
{ 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
public		 

class		 
DuesController		 
:		  !

Controller		" ,
{

 
private 
readonly 
IDuesBusiness &
_duesBusiness' 4
;4 5
public 
DuesController 
( 
IDuesBusiness +
duesBusiness, 8
)8 9
{ 	
_duesBusiness 
= 
duesBusiness (
;( )
} 	
[ 	
HttpPost	 
( 
$str 
)  
]  !
public 
IActionResult 
InsertRange (
(( )
InsertRangeDuesDto) ;
insertRangeDuesDto< N
)N O
{ 	
return 
Ok 
( 
_duesBusiness #
.# $
InsertRange$ /
(/ 0
insertRangeDuesDto0 B
)B C
)C D
;D E
} 	
} 
} Ç
qC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.WebAPI\Controllers\SuiteController.cs
	namespace 	#
InvoiceManagementSystem
 !
.! "
WebAPI" (
.( )
Controllers) 4
{ 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
public		 

class		 
SuiteController		  
:		! "

Controller		# -
{

 
private 
readonly 
ISuiteBusiness '
_suiteBusiness( 6
;6 7
public 
SuiteController 
( 
ISuiteBusiness -
suiteBusiness. ;
); <
{ 	
_suiteBusiness 
= 
suiteBusiness *
;* +
} 	
[ 	
HttpPost	 
( 
$str 
)  
]  !
public 
IActionResult 
Insert #
(# $
CreateSuiteDto$ 2
createSuiteDto3 A
)A B
{ 	
return 
Ok 
( 
_suiteBusiness $
.$ %
Insert% +
(+ ,
createSuiteDto, :
): ;
); <
;< =
} 	
[ 	
HttpGet	 
( 
$str (
)( )
]) *
public 
IActionResult 
GetAll #
(# $
)$ %
{ 	
return 
Ok 
( 
_suiteBusiness $
.$ %
GetAll% +
(+ ,
), -
)- .
;. /
} 	
[ 	
HttpPut	 
( 
$str 
) 
]  
public 
IActionResult 
Update #
(# $
UpdateSuiteDto$ 2
updateSuiteDto3 A
)A B
{   	
return!! 
Ok!! 
(!! 
_suiteBusiness!! $
.!!$ %
Update!!% +
(!!+ ,
updateSuiteDto!!, :
)!!: ;
)!!; <
;!!< =
}"" 	
[$$ 	

HttpDelete$$	 
($$ 
$str$$ !
)$$! "
]$$" #
public%% 
IActionResult%% 
Delete%% #
(%%# $
int%%$ '
suiteId%%( /
)%%/ 0
{&& 	
return'' 
Ok'' 
('' 
_suiteBusiness'' $
.''$ %
Delete''% +
(''+ ,
suiteId'', 3
)''3 4
)''4 5
;''5 6
}(( 	
})) 
}** Œ
pC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.WebAPI\Controllers\UserController.cs
	namespace 	#
InvoiceManagementSystem
 !
.! "
WebAPI" (
.( )
Controllers) 4
{ 
[ 
ApiController 
] 
[		 
Route		 

(		
 
$str		 
)		 
]		 
public

 

class

 
UserController

 
:

  !

Controller

" ,
{ 
private 
readonly 
IUserBusiness &
_userBusiness' 4
;4 5
public 
UserController 
( 
IUserBusiness +
userBusiness, 8
)8 9
{ 	
_userBusiness 
= 
userBusiness (
;( )
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
public 
IActionResult 
GetApartments *
(* +
)+ ,
{ 	
return 
Ok 
( 
_userBusiness #
.# $
GetAll$ *
(* +
)+ ,
), -
;- .
} 	
[ 	
HttpGet	 
( 
$str 
) 
]  
public 
IActionResult 
GetApartmentById -
(- .
int. 1
userId2 8
)8 9
{ 	
return 
Ok 
( 
_userBusiness #
.# $
GetById$ +
(+ ,
userId, 2
)2 3
)3 4
;4 5
} 	
[ 	
HttpPost	 
( 
$str 
) 
]  
public   
IActionResult   
Insert   #
(  # $
UserInsertDto  $ 1
userInsertDto  2 ?
)  ? @
{!! 	
return"" 
Ok"" 
("" 
_userBusiness"" #
.""# $
Insert""$ *
(""* +
userInsertDto""+ 8
)""8 9
)""9 :
;"": ;
}## 	
[%% 	
HttpPut%%	 
(%% 
$str%% 
)%% 
]%% 
public&& 
IActionResult&& 
Update&& #
(&&# $
UserInsertDto&&$ 1
userInsertDto&&2 ?
)&&? @
{'' 	
return(( 
Ok(( 
((( 
_userBusiness(( #
.((# $
Update(($ *
(((* +
userInsertDto((+ 8
)((8 9
)((9 :
;((: ;
})) 	
[++ 	

HttpDelete++	 
(++ 
$str++  
)++  !
]++! "
public,, 
IActionResult,, 
Delete,, #
(,,# $
int,,$ '
userId,,( .
),,. /
{-- 	
return.. 
Ok.. 
(.. 
_userBusiness.. #
...# $
Delete..$ *
(..* +
userId..+ 1
)..1 2
)..2 3
;..3 4
}// 	
}00 
}11 Ñ
]C:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.WebAPI\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder

 
.

 
Services

 
.

 
AddControllers

 
(

  
)

  !
;

! "
builder 
. 
Services 
. #
AddEndpointsApiExplorer (
(( )
)) *
;* +
builder 
. 
Services 
. 
AddSwaggerGen 
( 
)  
;  !
builder 
. 
Services 
. 
AddSingleton 
<  
IApartmentRepository 2
,2 3
ApartmentRepository4 G
>G H
(H I
)I J
;J K
builder 
. 
Services 
. 
AddSingleton 
< 
IApartmentBusiness 0
,0 1
ApartmentBusiness2 C
>C D
(D E
)E F
;F G
builder 
. 
Services 
. 
AddSingleton 
< 
ISuiteRepository .
,. /
SuiteRepository0 ?
>? @
(@ A
)A B
;B C
builder 
. 
Services 
. 
AddSingleton 
< 
ISuiteBusiness ,
,, -
SuiteBusiness. ;
>; <
(< =
)= >
;> ?
builder 
. 
Services 
. 
AddSingleton 
< 
IUserRepository -
,- .
UserRepository/ =
>= >
(> ?
)? @
;@ A
builder 
. 
Services 
. 
AddSingleton 
< 
IUserBusiness +
,+ ,
UserBusiness- 9
>9 :
(: ;
); <
;< =
builder 
. 
Services 
. 
AddSingleton 
< 
IDuesRepository -
,- .
DuesRepository/ =
>= >
(> ?
)? @
;@ A
builder 
. 
Services 
. 
AddSingleton 
< 
IDuesBusiness +
,+ ,
DuesBusiness- 9
>9 :
(: ;
); <
;< =
var 
app 
= 	
builder
 
. 
Build 
( 
) 
; 
if 
( 
app 
. 
Environment 
. 
IsDevelopment !
(! "
)" #
)# $
{ 
app   
.   

UseSwagger   
(   
)   
;   
app!! 
.!! 
UseSwaggerUI!! 
(!! 
)!! 
;!! 
}"" 

AppContext## 

.##
 
	SetSwitch## 
(## 
$str## ;
,##; <
true##= A
)##A B
;##B C
app%% 
.%% 
UseHttpsRedirection%% 
(%% 
)%% 
;%% 
app'' 
.'' 
UseAuthorization'' 
('' 
)'' 
;'' 
app)) 
.)) 
MapControllers)) 
()) 
))) 
;)) 
app++ 
.++ 
Run++ 
(++ 
)++ 	
;++	 
