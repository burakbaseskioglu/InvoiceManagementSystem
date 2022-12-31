æ2
{C:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Core\DataAccess\EntityFramework\EfRepository.cs
	namespace		 	#
InvoiceManagementSystem		
 !
.		! "
Core		" &
.		& '

DataAccess		' 1
.		1 2
EntityFramework		2 A
{

 
public 

class 
EfRepository 
< 
T 
,  
TContext! )
>) *
:+ ,
IRepository- 8
<8 9
T9 :
>: ;
where< A
TB C
:D E
classF K
whereL Q
TContextR Z
:[ \
	DbContext] f
,f g
newh k
(k l
)l m
{ 
public 
void 
Delete 
( 
T 
entiny #
)# $
{ 	
using 
( 
TContext 
context #
=$ %
new& )
TContext* 2
(2 3
)3 4
)4 5
{ 
context 
. 
Entry 
( 
entiny $
)$ %
.% &
State& +
=, -
EntityState. 9
.9 :
Deleted: A
;A B
context 
. 
SaveChanges #
(# $
)$ %
;% &
} 
} 	
public 
T 
Get 
( 

Expression 
<  
Func  $
<$ %
T% &
,& '
bool( ,
>, -
>- .
	predicate/ 8
)8 9
{ 	
using 
( 
TContext 
context #
=$ %
new& )
TContext* 2
(2 3
)3 4
)4 5
{ 
return 
context 
. 
Set "
<" #
T# $
>$ %
(% &
)& '
.' (
SingleOrDefault( 7
(7 8
	predicate8 A
)A B
;B C
} 
} 	
public 
List 
< 
T 
> 
GetAll 
( 

Expression (
<( )
Func) -
<- .
T. /
,/ 0
bool1 5
>5 6
>6 7
	predicate8 A
=B C
nullD H
)H I
{ 	
using   
(   
TContext   
context   #
=  $ %
new  & )
TContext  * 2
(  2 3
)  3 4
)  4 5
{!! 
return"" 
	predicate""  
==""! #
null""$ (
?"") *
context""+ 2
.""2 3
Set""3 6
<""6 7
T""7 8
>""8 9
(""9 :
)"": ;
.""; <
ToList""< B
(""B C
)""C D
:""E F
context""G N
.""N O
Set""O R
<""R S
T""S T
>""T U
(""U V
)""V W
.""W X
Where""X ]
(""] ^
	predicate""^ g
)""g h
.""h i
ToList""i o
(""o p
)""p q
;""q r
}## 
}$$ 	
public&& 
void&& 
Insert&& 
(&& 
T&& 
entity&& #
)&&# $
{'' 	
using(( 
((( 
TContext(( 
context(( #
=(($ %
new((& )
TContext((* 2
(((2 3
)((3 4
)((4 5
{)) 
var** 
addedEntity** 
=**  !
context**" )
.**) *
Entry*** /
(**/ 0
entity**0 6
)**6 7
;**7 8
addedEntity++ 
.++ 
State++ !
=++" #
EntityState++$ /
.++/ 0
Added++0 5
;++5 6
context,, 
.,, 
SaveChanges,, #
(,,# $
),,$ %
;,,% &
}-- 
}.. 	
public00 
void00 
InsertRange00 
(00  
List00  $
<00$ %
T00% &
>00& '
entity00( .
)00. /
{11 	
using22 
(22 
TContext22 
context22 #
=22$ %
new22& )
TContext22* 2
(222 3
)223 4
)224 5
{33 
context44 
.44 
Set44 
<44 
T44 
>44 
(44 
)44  
.44  !
AddRange44! )
(44) *
entity44* 0
)440 1
;441 2
context55 
.55 
SaveChanges55 #
(55# $
)55$ %
;55% &
}66 
}77 	
public99 
void99 
Update99 
(99 
T99 
entity99 #
)99# $
{:: 	
using;; 
(;; 
TContext;; 
context;; #
=;;$ %
new;;& )
TContext;;* 2
(;;2 3
);;3 4
);;4 5
{<< 
var== 
updatedEntity== !
===" #
context==$ +
.==+ ,
Entry==, 1
(==1 2
entity==2 8
)==8 9
;==9 :
updatedEntity>> 
.>> 
State>> #
=>>$ %
EntityState>>& 1
.>>1 2
Modified>>2 :
;>>: ;
context?? 
.?? 
SaveChanges?? #
(??# $
)??$ %
;??% &
}@@ 
}AA 	
publicCC 
voidCC 
UpdateRangeCC 
(CC  
ListCC  $
<CC$ %
TCC% &
>CC& '
entitiesCC( 0
)CC0 1
{DD 	
usingEE 
(EE 
TContextEE 
contextEE #
=EE$ %
newEE& )
TContextEE* 2
(EE2 3
)EE3 4
)EE4 5
{FF 
contextGG 
.GG 
SetGG 
<GG 
TGG 
>GG 
(GG 
)GG  
.GG  !
UpdateRangeGG! ,
(GG, -
entitiesGG- 5
)GG5 6
;GG6 7
contextHH 
.HH 
SaveChangesHH #
(HH# $
)HH$ %
;HH% &
}II 
}JJ 	
}KK 
}LL ™
zC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Core\DataAccess\EntityFramework\IRepository.cs
	namespace 	#
InvoiceManagementSystem
 !
.! "
Core" &
.& '

DataAccess' 1
.1 2
EntityFramework2 A
{		 
public

 

	interface

 
IRepository

  
<

  !
T

! "
>

" #
where

$ )
T

* +
:

, -
class

. 3
{ 
void 
Insert 
( 
T 
entity 
) 
; 
void 
InsertRange 
( 
List 
< 
T 
>  
entity! '
)' (
;( )
void 
Delete 
( 
T 
entiny 
) 
; 
void 
Update 
( 
T 
entity 
) 
; 
void 
UpdateRange 
( 
List 
< 
T 
>  
entities! )
)) *
;* +
T 	
Get
 
( 

Expression 
< 
Func 
< 
T 
,  
bool! %
>% &
>& '
	predicate( 1
)1 2
;2 3
List 
< 
T 
> 
GetAll 
( 

Expression !
<! "
Func" &
<& '
T' (
,( )
bool* .
>. /
>/ 0
	predicate1 :
=; <
null= A
)A B
;B C
} 
} †
eC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Core\Entity\BaseEntity.cs
	namespace 	#
InvoiceManagementSystem
 !
.! "
Core" &
.& '
Entity' -
{ 
public		 

class		 

BaseEntity		 
{

 
public 
bool 
IsActive 
{ 
get "
;" #
set$ '
;' (
}) *
public 
DateTime 
? 
CreatedDate $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
DateTime 
? 
UpdatedDate $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
DateTime 
? 
DeletedDate $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
} ”
gC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Core\Enums\BillingPeriod.cs
	namespace 	#
InvoiceManagementSystem
 !
.! "
Core" &
.& '
Enums' ,
{ 
public		 

enum		 
BillingPeriod		 
{

 
January 
= 
$num 
, 
February 
, 
March 
, 
April 
, 
May 
, 
June 
, 
July 
, 
Aug 
, 
Sep 
, 
Oct 
, 
Nov 
, 
December 
, 
} 
} þ
bC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Core\Enums\BillType.cs
	namespace 	#
InvoiceManagementSystem
 !
.! "
Core" &
.& '
Enums' ,
{ 
public		 

enum		 
BillType		 
{

 
Dues 
= 
$num 
, 
Electric 
, 
Gas 
, 
Water 
, 
} 
} ˜
fC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Core\Enums\StandardUser.cs
	namespace 	#
InvoiceManagementSystem
 !
.! "
Core" &
.& '
Enums' ,
{ 
public		 

enum		 
StandardUser		 
{

 
StandardUser 
= 
$num 
} 
} ª
oC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Core\Utilities\Result\DataResult.cs
	namespace 	#
InvoiceManagementSystem
 !
.! "
Core" &
.& '
	Utilities' 0
.0 1
Result1 7
{ 
public		 

class		 

DataResult		 
<		 
T		 
>		 
:		  
Result		! '
,		' (
IDataResult		) 4
<		4 5
T		5 6
>		6 7
{

 
public 

DataResult 
( 
T 
data  
,  !
bool" &
success' .
,. /
string0 6
message7 >
)> ?
:? @
base@ D
(D E
successE L
,L M
messageN U
)U V
{ 	
Data 
= 
data 
; 
} 	
public 

DataResult 
( 
T 
data  
,  !
bool" &
success' .
). /
:/ 0
base0 4
(4 5
success5 <
)< =
{ 	
Data 
= 
data 
; 
} 	
public 
T 
Data 
{ 
get 
; 
} 
} 
} ¥
tC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Core\Utilities\Result\ErrorDataResult.cs
	namespace 	#
InvoiceManagementSystem
 !
.! "
Core" &
.& '
	Utilities' 0
.0 1
Result1 7
{ 
public		 

class		 
ErrorDataResult		  
<		  !
T		! "
>		" #
:		$ %

DataResult		& 0
<		0 1
T		1 2
>		2 3
{

 
public 
ErrorDataResult 
( 
T  
data! %
)% &
:' (
base) -
(- .
data. 2
,2 3
false4 9
)9 :
{ 	
} 	
public 
ErrorDataResult 
( 
string %
message& -
)- .
:/ 0
base1 5
(5 6
default6 =
,= >
false? D
,D E
messageF M
)M N
{ 	
} 	
public 
ErrorDataResult 
( 
T  
data! %
,% &
string' -
message. 5
)5 6
:7 8
base9 =
(= >
data> B
,B C
falseD I
,I J
messageK R
)R S
{ 	
} 	
} 
} ô
pC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Core\Utilities\Result\ErrorResult.cs
	namespace 	#
InvoiceManagementSystem
 !
.! "
Core" &
.& '
	Utilities' 0
.0 1
Result1 7
{ 
public		 

class		 
ErrorResult		 
:		 
Result		 %
{

 
public 
ErrorResult 
( 
) 
: 
base #
(# $
false$ )
)) *
{ 	
} 	
public 
ErrorResult 
( 
string !
message" )
)) *
:+ ,
base- 1
(1 2
false2 7
,7 8
message9 @
)@ A
{ 	
} 	
} 
} Â
pC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Core\Utilities\Result\IDataResult.cs
	namespace 	#
InvoiceManagementSystem
 !
.! "
Core" &
.& '
	Utilities' 0
.0 1
Result1 7
{ 
public		 

	interface		 
IDataResult		  
<		  !
T		! "
>		" #
:		# $
IResult		$ +
{

 
T 	
Data
 
{ 
get 
; 
} 
} 
} Ö
lC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Core\Utilities\Result\IResult.cs
	namespace 	#
InvoiceManagementSystem
 !
.! "
Core" &
.& '
	Utilities' 0
.0 1
Result1 7
{ 
public		 

	interface		 
IResult		 
{

 
bool 
Success 
{ 
get 
; 
} 
string 
Message 
{ 
get 
; 
} 
} 
} Î	
kC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Core\Utilities\Result\Result.cs
	namespace 	#
InvoiceManagementSystem
 !
.! "
Core" &
.& '
	Utilities' 0
.0 1
Result1 7
{ 
public		 

class		 
Result		 
:		 
IResult		 !
{

 
public 
Result 
( 
bool 
success "
," #
string$ *
message+ 2
)2 3
:3 4
this5 9
(9 :
success: A
)A B
{ 	
Message 
= 
message 
; 
} 	
public 
Result 
( 
bool 
success "
)" #
{ 	
Success 
= 
success 
; 
} 	
public 
bool 
Success 
{ 
get !
;! "
}# $
public 
string 
Message 
{ 
get  #
;# $
}% &
} 
} û
vC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Core\Utilities\Result\SuccessDataResult.cs
	namespace 	#
InvoiceManagementSystem
 !
.! "
Core" &
.& '
	Utilities' 0
.0 1
Result1 7
{ 
public		 

class		 
SuccessDataResult		 "
<		" #
T		# $
>		$ %
:		& '

DataResult		( 2
<		2 3
T		3 4
>		4 5
{

 
public 
SuccessDataResult  
(  !
T! "
data# '
)' (
:) *
base+ /
(/ 0
data0 4
,4 5
true6 :
): ;
{ 	
} 	
public 
SuccessDataResult  
(  !
T! "
data# '
,' (
string) /
message0 7
)7 8
:9 :
base; ?
(? @
data@ D
,D E
trueF J
,J K
messageL S
)S T
{ 	
} 	
} 
} ú
rC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Core\Utilities\Result\SuccessResult.cs
	namespace 	#
InvoiceManagementSystem
 !
.! "
Core" &
.& '
	Utilities' 0
.0 1
Result1 7
{ 
public		 

class		 
SuccessResult		 
:		  
Result		! '
{

 
public 
SuccessResult 
( 
string #
message$ +
)+ ,
:- .
base/ 3
(3 4
true4 8
,8 9
message: A
)A B
{ 	
} 	
public 
SuccessResult 
( 
) 
:  
base! %
(% &
true& *
)* +
{ 	
} 	
} 
} 