å

sC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Business\Abstract\IApartmentBusiness.cs
	namespace

 	#
InvoiceManagementSystem


 !
.

! "
Business

" *
.

* +
Abstract

+ 3
{ 
public 

	interface 
IApartmentBusiness '
{ 
IResult 
Insert 
( 
ApartmentDto #
apartmentDto$ 0
)0 1
;1 2
IResult 
Delete 
( 
int 
apartmentId &
)& '
;' (
IResult 
Update 
( 
ApartmentDto #
apartmentDto$ 0
)0 1
;1 2
IDataResult 
< 
List 
< 
ApartmentDto %
>% &
>& '
GetAll( .
(. /
)/ 0
;0 1
IDataResult 
< 
ApartmentDto  
>  !
GetApartmentByName" 4
(4 5
string5 ;
apartmentName< I
)I J
;J K
IDataResult 
< 
ApartmentDto  
>  !
GetApartmentById" 2
(2 3
int3 6
apartmentId7 B
)B C
;C D
} 
} ™
nC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Business\Abstract\IDuesBusiness.cs
	namespace

 	#
InvoiceManagementSystem


 !
.

! "
Business

" *
.

* +
Abstract

+ 3
{ 
public 

	interface 
IDuesBusiness "
{ 
IResult 
Insert 
( 
InsertDuesDto $
insertDuesDto% 2
)2 3
;3 4
IResult 
InsertRange 
( 
InsertRangeDuesDto .
insertRangeDuesDto/ A
)A B
;B C
} 
} Ë
oC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Business\Abstract\ISuiteBusiness.cs
	namespace

 	#
InvoiceManagementSystem


 !
.

! "
Business

" *
.

* +
Abstract

+ 3
{ 
public 

	interface 
ISuiteBusiness #
{ 
IResult 
Insert 
( 
CreateSuiteDto %
createSuiteDto& 4
)4 5
;5 6
IResult 
InsertRange 
( 
InsertRangeSuiteDto /
suiteDto0 8
)8 9
;9 :
IResult 
Update 
( 
UpdateSuiteDto %
updateSuiteDto& 4
)4 5
;5 6
IResult 
Delete 
( 
int 
suiteId "
)" #
;# $
IDataResult 
< 
List 
< 
SuiteDto !
>! "
>" #
GetAll$ *
(* +
)+ ,
;, -
IDataResult 
< 
SuiteDto 
> 
GetById %
(% &
int& )
suiteId* 1
)1 2
;2 3
IResult 
UpdateRange 
( 
string "
type# '
,' (
int) ,
apartmentId- 8
)8 9
;9 :
} 
} ¥

nC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Business\Abstract\IUserBusiness.cs
	namespace

 	#
InvoiceManagementSystem


 !
.

! "
Business

" *
.

* +
Abstract

+ 3
{ 
public 

	interface 
IUserBusiness "
{ 
IDataResult 
< 
List 
< 
UserDto  
>  !
>! "
GetAll# )
() *
)* +
;+ ,
IDataResult 
< 
UserDto 
> 
GetById $
($ %
int% (
userId) /
)/ 0
;0 1
IResult 
Insert 
( 
UserInsertDto $
userInsertDto% 2
)2 3
;3 4
IResult 
Update 
( 
UserInsertDto $
userInsertDto% 2
)2 3
;3 4
IResult 
Delete 
( 
int 
userId !
)! "
;" #
IDataResult 
< 
User 
> 
GetUser !
(! "
int" %
userId& ,
), -
;- .
} 
} °t
rC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Business\Concrete\ApartmentBusiness.cs
	namespace 	#
InvoiceManagementSystem
 !
.! "
Business" *
.* +
Concrete+ 3
{ 
public 

class 
ApartmentBusiness "
:# $
IApartmentBusiness% 7
{ 
private 
readonly  
IApartmentRepository - 
_apartmentRepository. B
;B C
private 
readonly 
ISuiteBusiness '
_suiteBusiness( 6
;6 7
public 
ApartmentBusiness  
(  ! 
IApartmentRepository! 5
apartmentRepository6 I
,I J
ISuiteBusinessK Y
suiteBusinessZ g
)g h
{ 	 
_apartmentRepository  
=! "
apartmentRepository# 6
;6 7
_suiteBusiness 
= 
suiteBusiness *
;* +
} 	
public 
IResult 
Delete 
( 
int !
apartmentId" -
)- .
{ 	
var 
	apartment 
=  
_apartmentRepository 0
.0 1
Get1 4
(4 5
x5 6
=>7 9
x: ;
.; <
Id< >
==? A
apartmentIdB M
)M N
;N O
if 
( 
	apartment 
!= 
null !
)! "
{ 
	apartment 
. 
IsActive "
=# $
false% *
;* +
	apartment   
.   
DeletedDate   %
=  & '
DateTime  ( 0
.  0 1
Now  1 4
;  4 5 
_apartmentRepository!! $
.!!$ %
Update!!% +
(!!+ ,
	apartment!!, 5
)!!5 6
;!!6 7
return"" 
new"" 
SuccessResult"" (
(""( )
)"") *
;""* +
}## 
return$$ 
new$$ 
ErrorResult$$ "
($$" #
)$$# $
;$$$ %
}%% 	
public'' 
IDataResult'' 
<'' 
ApartmentDto'' '
>''' (
GetApartmentByName'') ;
(''; <
string''< B
apartmentName''C P
)''P Q
{(( 	
var)) 
	apartment)) 
=))  
_apartmentRepository)) 0
.))0 1
Get))1 4
())4 5
x))5 6
=>))7 9
x)): ;
.)); <
Name))< @
.))@ A
ToLower))A H
())H I
)))I J
==))K M
apartmentName))N [
.))[ \
ToLower))\ c
())c d
)))d e
&&))f h
x))i j
.))j k
IsActive))k s
)))s t
;))t u
if** 
(** 
	apartment** 
!=** 
null** !
)**! "
{++ 
return,, 
new,, 
SuccessDataResult,, ,
<,,, -
ApartmentDto,,- 9
>,,9 :
(,,: ;
new-- 
ApartmentDto-- $
{.. 
Name// 
=// 
	apartment// (
.//( )
Name//) -
,//- .
NumberOfFloor00 %
=00& '
	apartment00( 1
.001 2
NumberOfFloor002 ?
,00? @
NumberOfSuite11 %
=11& '
	apartment11( 1
.111 2
NumberOfSuite112 ?
,11? @
Address22 
=22  !
	apartment22" +
.22+ ,
Address22, 3
,223 4
ApartmentNo33 #
=33$ %
	apartment33& /
.33/ 0
ApartmentNo330 ;
,33; <
	BlockCode44 !
=44" #
	apartment44$ -
.44- .
	BlockCode44. 7
,447 8
ManagementId55 $
=55% &
	apartment55' 0
.550 1
ManagementId551 =
}66 
)66 
;66 
}77 
return88 
new88 
ErrorDataResult88 &
<88& '
ApartmentDto88' 3
>883 4
(884 5
$str885 J
)88J K
;88K L
}99 	
public;; 
IDataResult;; 
<;; 
List;; 
<;;  
ApartmentDto;;  ,
>;;, -
>;;- .
GetAll;;/ 5
(;;5 6
);;6 7
{<< 	
var== 
getAllApartment== 
===  ! 
_apartmentRepository==" 6
.==6 7
GetAll==7 =
(=== >
x==> ?
=>==@ B
x==C D
.==D E
IsActive==E M
)==M N
.==N O
ToList==O U
(==U V
)==V W
;==W X
if>> 
(>> 
getAllApartment>> 
!=>>  "
null>># '
)>>' (
{?? 
var@@ 
apartmentList@@ !
=@@" #
new@@$ '
List@@( ,
<@@, -
ApartmentDto@@- 9
>@@9 :
(@@: ;
)@@; <
;@@< =
foreachAA 
(AA 
varAA 
	apartmentAA &
inAA' )
getAllApartmentAA* 9
)AA9 :
{BB 
apartmentListCC !
.CC! "
AddCC" %
(CC% &
newCC& )
ApartmentDtoCC* 6
(CC6 7
)CC7 8
{DD 
NameEE 
=EE 
	apartmentEE (
.EE( )
NameEE) -
,EE- .
NumberOfFloorFF %
=FF& '
	apartmentFF( 1
.FF1 2
NumberOfFloorFF2 ?
,FF? @
NumberOfSuiteGG %
=GG& '
	apartmentGG( 1
.GG1 2
NumberOfSuiteGG2 ?
,GG? @
ApartmentNoHH #
=HH$ %
	apartmentHH& /
.HH/ 0
ApartmentNoHH0 ;
,HH; <
AddressII 
=II  !
	apartmentII" +
.II+ ,
AddressII, 3
,II3 4
	BlockCodeJJ !
=JJ" #
	apartmentJJ$ -
.JJ- .
	BlockCodeJJ. 7
,JJ7 8
}KK 
)KK 
;KK 
}LL 
returnMM 
newMM 
SuccessDataResultMM ,
<MM, -
ListMM- 1
<MM1 2
ApartmentDtoMM2 >
>MM> ?
>MM? @
(MM@ A
apartmentListMMA N
)MMN O
;MMO P
}NN 
returnOO 
newOO 
ErrorDataResultOO &
<OO& '
ListOO' +
<OO+ ,
ApartmentDtoOO, 8
>OO8 9
>OO9 :
(OO: ;
$strOO; Y
)OOY Z
;OOZ [
}PP 	
publicRR 
IResultRR 
InsertRR 
(RR 
ApartmentDtoRR *
apartmentDtoRR+ 7
)RR7 8
{SS 	
usingTT 
(TT 
TransactionScopeTT #
scopeTT$ )
=TT* +
newTT, /
TransactionScopeTT0 @
(TT@ A
)TTA B
)TTB C
{UU 
tryVV 
{WW 
varXX 
getApartmentXX $
=XX% & 
_apartmentRepositoryXX' ;
.XX; <
GetXX< ?
(XX? @
xXX@ A
=>XXB D
xXXE F
.XXF G
ApartmentNoXXG R
==XXS U
apartmentDtoXXV b
.XXb c
ApartmentNoXXc n
)XXn o
;XXo p
ifYY 
(YY 
getApartmentYY $
==YY% '
nullYY( ,
)YY, -
{ZZ 
var[[ 
	apartment[[ %
=[[& '
new[[( +
	Apartment[[, 5
{\\ 
IsActive]] $
=]]% &
true]]' +
,]]+ ,
CreatedDate^^ '
=^^( )
DateTime^^* 2
.^^2 3
Now^^3 6
,^^6 7
Name__  
=__! "
apartmentDto__# /
.__/ 0
Name__0 4
,__4 5
NumberOfFloor`` )
=``* +
apartmentDto``, 8
.``8 9
NumberOfFloor``9 F
,``F G
NumberOfSuiteaa )
=aa* +
apartmentDtoaa, 8
.aa8 9
NumberOfSuiteaa9 F
,aaF G
ManagementIdbb (
=bb) *
apartmentDtobb+ 7
.bb7 8
ManagementIdbb8 D
,bbD E
	BlockCodecc %
=cc& '
apartmentDtocc( 4
.cc4 5
	BlockCodecc5 >
,cc> ?
ApartmentNodd '
=dd( )
apartmentDtodd* 6
.dd6 7
ApartmentNodd7 B
,ddB C
Addressee #
=ee$ %
apartmentDtoee& 2
.ee2 3
Addressee3 :
,ee: ;
}ff 
;ff  
_apartmentRepositorygg ,
.gg, -
Insertgg- 3
(gg3 4
	apartmentgg4 =
)gg= >
;gg> ?
_suiteBusinesshh &
.hh& '
InsertRangehh' 2
(hh2 3
newhh3 6
InsertRangeSuiteDtohh7 J
{ii 
	BlockCodejj %
=jj& '
apartmentDtojj( 4
.jj4 5
	BlockCodejj5 >
,jj> ?
NumberOfFloorkk )
=kk* +
apartmentDtokk, 8
.kk8 9
NumberOfFloorkk9 F
,kkF G
SuiteOfFloorCountll -
=ll. /
apartmentDtoll0 <
.ll< =
SuiteOfFloorCountll= N
,llN O
Typemm  
=mm! "
apartmentDtomm# /
.mm/ 0
	SuiteTypemm0 9
,mm9 :
ApartmentIdnn '
=nn( )
	apartmentnn* 3
.nn3 4
Idnn4 6
}oo 
)oo 
;oo 
scopepp 
.pp 
Completepp &
(pp& '
)pp' (
;pp( )
returnqq 
newqq "
SuccessResultqq# 0
(qq0 1
$strqq1 T
)qqT U
;qqU V
}rr 
returnss 
newss 
ErrorResultss *
(ss* +
$strss+ X
)ssX Y
;ssY Z
}tt 
catchuu 
(uu 
	Exceptionuu  
exuu! #
)uu# $
{vv 
scopeww 
.ww 
Disposeww !
(ww! "
)ww" #
;ww# $
returnxx 
newxx 
ErrorResultxx *
(xx* +
$"xx+ -
$strxx- >
{xx> ?
exxx? A
.xxA B
MessagexxB I
}xxI J
"xxJ K
)xxK L
;xxL M
}yy 
}zz 
}{{ 	
public}} 
IResult}} 
Update}} 
(}} 
ApartmentDto}} *
apartmentDto}}+ 7
)}}7 8
{~~ 	
var 
	apartment 
=  
_apartmentRepository 0
.0 1
Get1 4
(4 5
x5 6
=>7 9
x: ;
.; <
Name< @
==A C
apartmentDtoD P
.P Q
NameQ U
&&V X
xY Z
.Z [
IsActive[ c
)c d
;d e
if
€€ 
(
€€ 
	apartment
€€ 
!=
€€ 
null
€€ !
)
€€! "
{
 
	apartment
‚‚ 
.
‚‚ 
UpdatedDate
‚‚ %
=
‚‚& '
DateTime
‚‚( 0
.
‚‚0 1
Now
‚‚1 4
;
‚‚4 5
	apartment
ƒƒ 
.
ƒƒ 
Name
ƒƒ 
=
ƒƒ  
apartmentDto
ƒƒ! -
.
ƒƒ- .
Name
ƒƒ. 2
;
ƒƒ2 3
	apartment
„„ 
.
„„ 
ManagementId
„„ &
=
„„' (
apartmentDto
„„) 5
.
„„5 6
ManagementId
„„6 B
;
„„B C
	apartment
…… 
.
…… 
NumberOfSuite
…… '
=
……( )
apartmentDto
……* 6
.
……6 7
NumberOfSuite
……7 D
;
……D E
	apartment
†† 
.
†† 
NumberOfFloor
†† '
=
††( )
apartmentDto
††* 6
.
††6 7
NumberOfFloor
††7 D
;
††D E
	apartment
‡‡ 
.
‡‡ 
Address
‡‡ !
=
‡‡" #
apartmentDto
‡‡$ 0
.
‡‡0 1
Address
‡‡1 8
;
‡‡8 9"
_apartmentRepository
ˆˆ $
.
ˆˆ$ %
Update
ˆˆ% +
(
ˆˆ+ ,
	apartment
ˆˆ, 5
)
ˆˆ5 6
;
ˆˆ6 7
_suiteBusiness
ŠŠ 
.
ŠŠ 
UpdateRange
ŠŠ *
(
ŠŠ* +
apartmentDto
ŠŠ+ 7
.
ŠŠ7 8
	SuiteType
ŠŠ8 A
,
ŠŠA B
	apartment
ŠŠC L
.
ŠŠL M
Id
ŠŠM O
)
ŠŠO P
;
ŠŠP Q
return
ŒŒ 
new
ŒŒ 
SuccessResult
ŒŒ (
(
ŒŒ( )
)
ŒŒ) *
;
ŒŒ* +
}
 
return
ŽŽ 
new
ŽŽ 
ErrorResult
ŽŽ "
(
ŽŽ" #
$str
ŽŽ# 5
)
ŽŽ5 6
;
ŽŽ6 7
}
 	
public
‘‘ 
IDataResult
‘‘ 
<
‘‘ 
ApartmentDto
‘‘ '
>
‘‘' (
GetApartmentById
‘‘) 9
(
‘‘9 :
int
‘‘: =
apartmentId
‘‘> I
)
‘‘I J
{
’’ 	
var
““ 
	apartment
““ 
=
““ "
_apartmentRepository
““ 0
.
““0 1
Get
““1 4
(
““4 5
x
““5 6
=>
““7 9
x
““: ;
.
““; <
Id
““< >
==
““? A
apartmentId
““B M
&&
““N P
x
““Q R
.
““R S
IsActive
““S [
)
““[ \
;
““\ ]
if
”” 
(
”” 
	apartment
”” 
!=
”” 
null
”” !
)
””! "
{
•• 
return
–– 
new
–– 
SuccessDataResult
–– ,
<
––, -
ApartmentDto
––- 9
>
––9 :
(
––: ;
new
––; >
ApartmentDto
––? K
{
—— 
Name
˜˜ 
=
˜˜ 
	apartment
˜˜ $
.
˜˜$ %
Name
˜˜% )
,
˜˜) *
ApartmentNo
™™ 
=
™™  !
	apartment
™™" +
.
™™+ ,
ApartmentNo
™™, 7
,
™™7 8
	BlockCode
šš 
=
šš 
	apartment
šš  )
.
šš) *
	BlockCode
šš* 3
,
šš3 4
Address
›› 
=
›› 
	apartment
›› '
.
››' (
Address
››( /
,
››/ 0
NumberOfFloor
œœ !
=
œœ" #
	apartment
œœ$ -
.
œœ- .
NumberOfFloor
œœ. ;
,
œœ; <
}
 
)
 
;
 
}
žž 
return
ŸŸ 
new
ŸŸ 
ErrorDataResult
ŸŸ &
<
ŸŸ& '
ApartmentDto
ŸŸ' 3
>
ŸŸ3 4
(
ŸŸ4 5
$str
ŸŸ5 K
)
ŸŸK L
;
ŸŸL M
}
   	
}
¡¡ 
}¢¢ š,
mC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Business\Concrete\DuesBusiness.cs
	namespace 	#
InvoiceManagementSystem
 !
.! "
Business" *
.* +
Concrete+ 3
{ 
public 

class 
DuesBusiness 
: 
IDuesBusiness  -
{ 
private 
readonly 
IDuesRepository (
_duesRepository) 8
;8 9
private 
readonly 
IApartmentBusiness +
_apartmentBusiness, >
;> ?
private 
readonly 
ISuiteBusiness '
_suiteBusiness( 6
;6 7
public 
DuesBusiness 
( 
IDuesRepository +
duesRepository, :
,: ;
IApartmentBusiness< N
apartmentBusinessO `
,` a
ISuiteBusinessb p
suiteBusinessq ~
)~ 
{ 	
_duesRepository 
= 
duesRepository ,
;, -
_apartmentBusiness 
=  
apartmentBusiness! 2
;2 3
_suiteBusiness 
= 
suiteBusiness *
;* +
} 	
public 
IResult 
Insert 
( 
InsertDuesDto +
insertDuesDto, 9
)9 :
{ 	
var 
dues 
= 
_duesRepository &
.& '
Get' *
(* +
x+ ,
=>- /
x0 1
.1 2
SuiteId2 9
==: <
insertDuesDto= J
.J K
SuiteIdK R
&&S U
x 
. 
Type 
== 
insertDuesDto '
.' (
Type( ,
&&- /
x   
.   
BillingPeriod   
==    "
insertDuesDto  # 0
.  0 1
BillingPeriod  1 >
&&  ? A
x!! 
.!! 
IsActive!! 
==!! 
true!! "
)!!" #
;!!# $
if"" 
("" 
dues"" 
=="" 
null"" 
)"" 
{## 
_duesRepository$$ 
.$$  
Insert$$  &
($$& '
new$$' *
Dues$$+ /
{%% 
IsActive&& 
=&& 
true&& #
,&&# $
CreatedDate'' 
=''  !
DateTime''" *
.''* +
Now''+ .
,''. /
Type(( 
=(( 
insertDuesDto(( (
.((( )
Type(() -
,((- .
BillingPeriod)) !
=))" #
insertDuesDto))$ 1
.))1 2
BillingPeriod))2 ?
,))? @
Amount** 
=** 
insertDuesDto** *
.*** +
Amount**+ 1
,**1 2
SuiteId++ 
=++ 
insertDuesDto++ +
.+++ ,
SuiteId++, 3
,++3 4
},, 
),, 
;,, 
return-- 
new-- 
SuccessResult-- (
(--( )
)--) *
;--* +
}.. 
return// 
new// 
ErrorResult// "
(//" #
$str//# E
)//E F
;//F G
}00 	
public22 
IResult22 
InsertRange22 "
(22" #
InsertRangeDuesDto22# 5
insertRangeDuesDto226 H
)22H I
{33 	
var44 
	apartment44 
=44 
_apartmentBusiness44 .
.44. /
GetApartmentById44/ ?
(44? @
insertRangeDuesDto44@ R
.44R S
ApartmentId44S ^
)44^ _
;44_ `
var55 
suites55 
=55 
_suiteBusiness55 '
.55' (
GetAll55( .
(55. /
)55/ 0
.550 1
Data551 5
.555 6
Where556 ;
(55; <
x55< =
=>55> @
x55A B
.55B C
ApartmentId55C N
==55O Q
insertRangeDuesDto55R d
.55d e
ApartmentId55e p
)55p q
.55q r
ToList55r x
(55x y
)55y z
;55z {
if66 
(66 
suites66 
!=66 
null66 
)66 
{77 
foreach88 
(88 
var88 
suite88 "
in88# %
suites88& ,
)88, -
{99 
_duesRepository:: #
.::# $
Insert::$ *
(::* +
new::+ .
Dues::/ 3
{;; 
IsActive<<  
=<<! "
true<<# '
,<<' (
CreatedDate== #
===$ %
DateTime==& .
.==. /
Now==/ 2
,==2 3
Type>> 
=>> 
insertRangeDuesDto>> 1
.>>1 2
Type>>2 6
,>>6 7
Amount?? 
=??  
insertRangeDuesDto??! 3
.??3 4
Amount??4 :
,??: ;
BillingPeriod@@ %
=@@& '
insertRangeDuesDto@@( :
.@@: ;
BillingPeriod@@; H
,@@H I
SuiteIdAA 
=AA  !
suiteAA" '
.AA' (
SuiteIdAA( /
}BB 
)BB 
;BB 
}CC 
returnDD 
newDD 
SuccessResultDD (
(DD( )
$strDD) P
)DDP Q
;DDQ R
}EE 
returnFF 
newFF 
ErrorResultFF "
(FF" #
)FF# $
;FF$ %
}GG 	
}HH 
}II Öh
nC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Business\Concrete\SuiteBusiness.cs
	namespace 	#
InvoiceManagementSystem
 !
.! "
Business" *
.* +
Concrete+ 3
{ 
public 

class 
SuiteBusiness 
:  
ISuiteBusiness! /
{ 
private 
readonly 
ISuiteRepository )
_suiteRepository* :
;: ;
private 
readonly 
IUserBusiness &
_userBusiness' 4
;4 5
public 
SuiteBusiness 
( 
ISuiteRepository -
suiteRepository. =
,= >
IUserBusiness? L
userBusinessM Y
)Y Z
{ 	
_suiteRepository 
= 
suiteRepository .
;. /
_userBusiness 
= 
userBusiness (
;( )
} 	
public 
IResult 
Delete 
( 
int !
suiteId" )
)) *
{ 	
var 
suite 
= 
_suiteRepository (
.( )
Get) ,
(, -
x- .
=>/ 1
x2 3
.3 4
Id4 6
==7 9
suiteId: A
)A B
;B C
if 
( 
suite 
!= 
null 
) 
{ 
suite 
. 
IsActive 
=  
false! &
;& '
suite   
.   
DeletedDate   !
=  " #
DateTime  $ ,
.  , -
Now  - 0
;  0 1
_suiteRepository!!  
.!!  !
Update!!! '
(!!' (
suite!!( -
)!!- .
;!!. /
return"" 
new"" 
SuccessResult"" (
(""( )
)"") *
;""* +
}## 
return$$ 
new$$ 
ErrorResult$$ "
($$" #
$str$$# 6
)$$6 7
;$$7 8
}%% 	
public'' 
IDataResult'' 
<'' 
List'' 
<''  
SuiteDto''  (
>''( )
>'') *
GetAll''+ 1
(''1 2
)''2 3
{(( 	
var)) 
suites)) 
=)) 
_suiteRepository)) )
.))) *!
GetAllSuitesWithUsers))* ?
())? @
)))@ A
;))A B
if** 
(** 
suites** 
!=** 
null** 
)** 
{++ 
return,, 
new,, 
SuccessDataResult,, ,
<,,, -
List,,- 1
<,,1 2
SuiteDto,,2 :
>,,: ;
>,,; <
(,,< =
suites,,= C
),,C D
;,,D E
}-- 
return.. 
new.. 
ErrorDataResult.. &
<..& '
List..' +
<..+ ,
SuiteDto.., 4
>..4 5
>..5 6
(..6 7
$str..7 R
)..R S
;..S T
}// 	
public11 
IDataResult11 
<11 
SuiteDto11 #
>11# $
GetById11% ,
(11, -
int11- 0
suiteId111 8
)118 9
{22 	
var33 
suite33 
=33 
_suiteRepository33 (
.33( )
GetSuiteWithUser33) 9
(339 :
suiteId33: A
)33A B
;33B C
if44 
(44 
suite44 
!=44 
null44 
)44 
{55 
return66 
new66 
SuccessDataResult66 ,
<66, -
SuiteDto66- 5
>665 6
(666 7
suite667 <
)66< =
;66= >
}77 
return88 
new88 
ErrorDataResult88 &
<88& '
SuiteDto88' /
>88/ 0
(880 1
$str881 D
)88D E
;88E F
}99 	
public;; 
IResult;; 
Insert;; 
(;; 
CreateSuiteDto;; ,
createSuiteDto;;- ;
);;; <
{<< 	
if== 
(== 
createSuiteDto== 
!=== !
null==" &
)==& '
{>> 
_suiteRepository??  
.??  !
Insert??! '
(??' (
new??( +
Suite??, 1
{@@ 
IsActiveAA 
=AA 
trueAA #
,AA# $
CreatedDateBB 
=BB  !
DateTimeBB" *
.BB* +
NowBB+ .
,BB. /
BlockCC 
=CC 
createSuiteDtoCC *
.CC* +
BlockCC+ 0
,CC0 1
FloorDD 
=DD 
createSuiteDtoDD *
.DD* +
FloorDD+ 0
,DD0 1
TypeEE 
=EE 
createSuiteDtoEE )
.EE) *
TypeEE* .
,EE. /
NumberOfSuiteFF !
=FF" #
createSuiteDtoFF$ 2
.FF2 3

DoorNumberFF3 =
,FF= >
StatusGG 
=GG 
createSuiteDtoGG +
.GG+ ,
StatusGG, 2
,GG2 3
IsTenantHH 
=HH 
createSuiteDtoHH -
.HH- .
IsTenantHH. 6
,HH6 7
ApartmentIdII 
=II  !
createSuiteDtoII" 0
.II0 1
ApartmentIdII1 <
,II< =
UserIdJJ 
=JJ 
createSuiteDtoJJ +
.JJ+ ,
UserIdJJ, 2
}KK 
)KK 
;KK 
returnLL 
newLL 
SuccessResultLL (
(LL( )
)LL) *
;LL* +
}MM 
returnNN 
newNN 
ErrorResultNN "
(NN" #
)NN# $
;NN$ %
}OO 	
publicQQ 
IResultQQ 
InsertRangeQQ "
(QQ" #
InsertRangeSuiteDtoQQ# 6
suiteDtoQQ7 ?
)QQ? @
{RR 	
intSS 
kSS 
=SS 
$numSS 
;SS 
forTT 
(TT 
intTT 
iTT 
=TT 
$numTT 
;TT 
iTT 
<=TT  
suiteDtoTT! )
.TT) *
NumberOfFloorTT* 7
;TT7 8
iTT9 :
++TT: <
)TT< =
{UU 
forVV 
(VV 
intVV 
jVV 
=VV 
$numVV 
;VV 
jVV  !
<=VV" $
suiteDtoVV% -
.VV- .
SuiteOfFloorCountVV. ?
;VV? @
jVVA B
++VVB D
)VVD E
{WW 
varXX 
suiteXX 
=XX 
newXX  #
SuiteXX$ )
{YY 
IsActiveZZ  
=ZZ! "
trueZZ# '
,ZZ' (
CreatedDate[[ #
=[[$ %
DateTime[[& .
.[[. /
Now[[/ 2
,[[2 3
Block\\ 
=\\ 
suiteDto\\  (
.\\( )
	BlockCode\\) 2
,\\2 3
Floor]] 
=]] 
i]]  !
,]]! "
Type^^ 
=^^ 
suiteDto^^ '
.^^' (
Type^^( ,
,^^, -
NumberOfSuite__ %
=__& '
k__( )
++__) +
,__+ ,
Status`` 
=``  
false``! &
,``& '
IsTenantaa  
=aa! "
falseaa# (
,aa( )
UserIdbb 
=bb  
_userBusinessbb! .
.bb. /
GetUserbb/ 6
(bb6 7
(bb7 8
intbb8 ;
)bb; <
StandardUserbb< H
.bbH I
StandardUserbbI U
)bbU V
.bbV W
DatabbW [
.bb[ \
Idbb\ ^
,bb^ _
ApartmentIdcc #
=cc$ %
suiteDtocc& .
.cc. /
ApartmentIdcc/ :
}dd 
;dd 
_suiteRepositoryee $
.ee$ %
Insertee% +
(ee+ ,
suiteee, 1
)ee1 2
;ee2 3
}ff 
}gg 
returnii 
newii 
SuccessResultii $
(ii$ %
)ii% &
;ii& '
}jj 	
publicll 
IResultll 
Updatell 
(ll 
UpdateSuiteDtoll ,
updateSuiteDtoll- ;
)ll; <
{mm 	
varnn 
suitenn 
=nn 
_suiteRepositorynn (
.nn( )
GetSuiteWithUsernn) 9
(nn9 :
updateSuiteDtonn: H
.nnH I
SuiteIdnnI P
)nnP Q
;nnQ R
ifoo 
(oo 
suiteoo 
!=oo 
nulloo 
)oo 
{pp 
varqq 
newSuiteqq 
=qq 
newqq "
Suiteqq# (
{rr 
Idss 
=ss 
updateSuiteDtoss '
.ss' (
SuiteIdss( /
,ss/ 0
UpdatedDatett 
=tt  
DateTimett  (
.tt( )
Nowtt) ,
,tt, -
Blockuu 
=uu 
updateSuiteDtouu *
.uu* +
Blockuu+ 0
==uu1 3
defaultuu4 ;
?uu< =
suiteuu> C
.uuC D
BlockuuD I
:uuJ K
updateSuiteDtouuL Z
.uuZ [
Blockuu[ `
,uu` a
Floorvv 
=vv 
updateSuiteDtovv *
.vv* +
Floorvv+ 0
==vv1 3
defaultvv4 ;
?vv< =
suitevv> C
.vvC D
FloorvvD I
:vvJ K
updateSuiteDtovvL Z
.vvZ [
Floorvv[ `
,vv` a
Typeww 
=ww 
updateSuiteDtoww )
.ww) *
Typeww* .
==ww/ 1
defaultww2 9
?ww: ;
suiteww< A
.wwA B
TypewwB F
:wwG H
updateSuiteDtowwI W
.wwW X
TypewwX \
,ww\ ]
NumberOfSuitexx !
=xx" #
updateSuiteDtoxx$ 2
.xx2 3
NumberOfSuitexx3 @
==xxA C
defaultxxD K
?xxL M
suitexxN S
.xxS T
NumberOfSuitexxT a
:xxb c
updateSuiteDtoxxd r
.xxr s
NumberOfSuite	xxs €
,
xx€ 
ApartmentIdyy 
=yy  !
updateSuiteDtoyy" 0
.yy0 1
ApartmentIdyy1 <
==yy= ?
defaultyy@ G
?yyH I
suiteyyJ O
.yyO P
ApartmentIdyyP [
:yy\ ]
updateSuiteDtoyy^ l
.yyl m
ApartmentIdyym x
,yyx y
Statuszz 
=zz 
updateSuiteDtozz +
.zz+ ,
Statuszz, 2
==zz3 5
defaultzz6 =
?zz> ?
suitezz@ E
.zzE F
StatuszzF L
:zzM N
updateSuiteDtozzO ]
.zz] ^
Statuszz^ d
,zzd e
IsTenant{{ 
={{ 
updateSuiteDto{{ -
.{{- .
IsTenant{{. 6
=={{7 9
default{{: A
?{{B C
suite{{D I
.{{I J
IsTenant{{J R
:{{S T
updateSuiteDto{{U c
.{{c d
IsTenant{{d l
,{{l m
UserId|| 
=|| 
updateSuiteDto|| +
.||+ ,
OwnerId||, 3
==||4 6
default||7 >
?||? @
suite||A F
.||F G
OwnerId||G N
:||O P
updateSuiteDto||Q _
.||_ `
OwnerId||` g
,||g h
}}} 
;}} 
_suiteRepository~~  
.~~  !
Update~~! '
(~~' (
newSuite~~( 0
)~~0 1
;~~1 2
return 
new 
SuccessResult (
(( )
)) *
;* +
}
€€ 
return
 
new
 
ErrorResult
 "
(
" #
$str
# 6
)
6 7
;
7 8
}
‚‚ 	
public
„„ 
IResult
„„ 
UpdateRange
„„ "
(
„„" #
string
„„# )
type
„„* .
,
„„. /
int
„„0 3
apartmentId
„„4 ?
)
„„? @
{
…… 	
var
†† 
suites
†† 
=
†† 
_suiteRepository
†† )
.
††) *
GetAll
††* 0
(
††0 1
x
††1 2
=>
††3 5
x
††6 7
.
††7 8
ApartmentId
††8 C
==
††D F
apartmentId
††G R
)
††R S
;
††S T
var
‡‡ 
newlist
‡‡ 
=
‡‡ 
new
‡‡ 
List
‡‡ "
<
‡‡" #
Suite
‡‡# (
>
‡‡( )
(
‡‡) *
)
‡‡* +
;
‡‡+ ,
foreach
ˆˆ 
(
ˆˆ 
var
ˆˆ 
item
ˆˆ 
in
ˆˆ 
suites
ˆˆ  &
)
ˆˆ& '
{
‰‰ 
item
ŠŠ 
.
ŠŠ 
Type
ŠŠ 
=
ŠŠ 
type
ŠŠ  
;
ŠŠ  !
newlist
‹‹ 
.
‹‹ 
Add
‹‹ 
(
‹‹ 
item
‹‹  
)
‹‹  !
;
‹‹! "
}
ŒŒ 
_suiteRepository
ŽŽ 
.
ŽŽ 
UpdateRange
ŽŽ (
(
ŽŽ( )
newlist
ŽŽ) 0
)
ŽŽ0 1
;
ŽŽ1 2
return
 
new
 
SuccessResult
 $
(
$ %
)
% &
;
& '
}
‘‘ 	
}
¨¨ 
}©© Ém
mC:\Users\Burak\source\repos\InvoiceManagementSystem\InvoiceManagementSystem.Business\Concrete\UserBusiness.cs
	namespace 	#
InvoiceManagementSystem
 !
.! "
Business" *
.* +
Concrete+ 3
{ 
public 

class 
UserBusiness 
: 
IUserBusiness  -
{ 
private 
readonly 
IUserRepository (
_userRepository) 8
;8 9
public 
UserBusiness 
( 
IUserRepository +
userRepository, :
): ;
{ 	
_userRepository 
= 
userRepository ,
;, -
} 	
public 
IResult 
Delete 
( 
int !
userId" (
)( )
{ 	
var 
user 
= 
_userRepository &
.& '
Get' *
(* +
x+ ,
=>- /
x0 1
.1 2
Id2 4
==5 7
userId8 >
)> ?
;? @
if 
( 
user 
!= 
null 
) 
{ 
_userRepository 
.  
Update  &
(& '
new' *
User+ /
{ 
IsActive 
= 
false $
,$ %
DeletedDate   
=    !
DateTime  " *
.  * +
Now  + .
,  . /
}!! 
)!! 
;!! 
return"" 
new"" 
SuccessResult"" (
(""( )
$str"") =
)""= >
;""> ?
}## 
return$$ 
new$$ 
ErrorResult$$ "
($$" #
)$$# $
;$$$ %
}%% 	
public'' 
IDataResult'' 
<'' 
List'' 
<''  
UserDto''  '
>''' (
>''( )
GetAll''* 0
(''0 1
)''1 2
{(( 	
var)) 
users)) 
=)) 
_userRepository)) '
.))' (
GetAll))( .
()). /
x))/ 0
=>))1 3
x))4 5
.))5 6
IsActive))6 >
==))? A
true))B F
)))F G
;))G H
var** 
userList** 
=** 
new** 
List** #
<**# $
UserDto**$ +
>**+ ,
(**, -
)**- .
;**. /
if++ 
(++ 
users++ 
!=++ 
null++ 
)++ 
{,, 
foreach-- 
(-- 
var-- 
user-- !
in--" $
users--% *
)--* +
{.. 
userList// 
.// 
Add//  
(//  !
new//! $
UserDto//% ,
{00 
IsActive11  
=11! "
user11# '
.11' (
IsActive11( 0
,110 1
CreatedDate22 #
=22$ %
user22& *
.22* +
CreatedDate22+ 6
.226 7
Value227 <
.22< =
ToString22= E
(22E F
$str22F _
)22_ `
,22` a
	Firstname33 !
=33" #
user33$ (
.33( )
	Firstname33) 2
,332 3
Lastname44  
=44! "
user44# '
.44' (
Lastname44( 0
,440 1
IdentityNumber55 &
=55' (
user55) -
.55- .
IdentityNumber55. <
,55< =
Email66 
=66 
user66  $
.66$ %
Email66% *
,66* +
Phone77 
=77 
user77  $
.77$ %
Phone77% *
,77* +
LicensePlate88 $
=88% &
user88' +
.88+ ,
LicensePlate88, 8
,888 9
IsManagement99 $
=99% &
user99' +
.99+ ,
IsManagement99, 8
}:: 
):: 
;:: 
};; 
return<< 
new<< 
SuccessDataResult<< ,
<<<, -
List<<- 1
<<<1 2
UserDto<<2 9
><<9 :
><<: ;
(<<; <
userList<<< D
)<<D E
;<<E F
}== 
return>> 
new>> 
ErrorDataResult>> &
<>>& '
List>>' +
<>>+ ,
UserDto>>, 3
>>>3 4
>>>4 5
(>>5 6
$str>>6 U
)>>U V
;>>V W
}?? 	
publicAA 
IDataResultAA 
<AA 
UserDtoAA "
>AA" #
GetByIdAA$ +
(AA+ ,
intAA, /
userIdAA0 6
)AA6 7
{BB 	
varCC 
userCC 
=CC 
_userRepositoryCC &
.CC& '
GetCC' *
(CC* +
xCC+ ,
=>CC- /
xCC0 1
.CC1 2
IdCC2 4
==CC5 7
userIdCC8 >
&&CC? A
xCCB C
.CCC D
IsActiveCCD L
==CCM O
trueCCP T
)CCT U
;CCU V
varDD 
newUserDD 
=DD 
newDD 
UserDtoDD %
(DD% &
)DD& '
;DD' (
ifFF 
(FF 
userFF 
!=FF 
nullFF 
)FF 
{GG 
newUserHH 
=HH 
newHH 
UserDtoHH %
{II 
IsActiveJJ 
=JJ 
userJJ #
.JJ# $
IsActiveJJ$ ,
,JJ, -
CreatedDateKK 
=KK  !
userKK" &
.KK& '
CreatedDateKK' 2
.KK2 3
ValueKK3 8
.KK8 9
ToStringKK9 A
(KKA B
$strKKB [
)KK[ \
,KK\ ]
	FirstnameLL 
=LL 
userLL  $
.LL$ %
	FirstnameLL% .
,LL. /
LastnameMM 
=MM 
userMM #
.MM# $
LastnameMM$ ,
,MM, -
IdentityNumberNN "
=NN# $
userNN% )
.NN) *
IdentityNumberNN* 8
,NN8 9
EmailOO 
=OO 
userOO  
.OO  !
EmailOO! &
,OO& '
PhonePP 
=PP 
userPP  
.PP  !
PhonePP! &
,PP& '
LicensePlateQQ  
=QQ! "
userQQ# '
.QQ' (
LicensePlateQQ( 4
,QQ4 5
IsManagementRR  
=RR! "
userRR# '
.RR' (
IsManagementRR( 4
}SS 
;SS 
returnTT 
newTT 
SuccessDataResultTT ,
<TT, -
UserDtoTT- 4
>TT4 5
(TT5 6
newUserTT6 =
)TT= >
;TT> ?
}UU 
returnVV 
newVV 
ErrorDataResultVV &
<VV& '
UserDtoVV' .
>VV. /
(VV/ 0
newUserVV0 7
)VV7 8
;VV8 9
}WW 	
publicYY 
IDataResultYY 
<YY 
UserYY 
>YY  
GetUserYY! (
(YY( )
intYY) ,
userIdYY- 3
)YY3 4
{ZZ 	
var[[ 
user[[ 
=[[ 
_userRepository[[ &
.[[& '
Get[[' *
([[* +
x[[+ ,
=>[[- /
x[[0 1
.[[1 2
Id[[2 4
==[[5 7
userId[[8 >
&&[[? A
x[[B C
.[[C D
IsActive[[D L
==[[M O
true[[P T
)[[T U
;[[U V
if\\ 
(\\ 
user\\ 
!=\\ 
null\\ 
)\\ 
{]] 
return^^ 
new^^ 
SuccessDataResult^^ ,
<^^, -
User^^- 1
>^^1 2
(^^2 3
user^^3 7
)^^7 8
;^^8 9
}__ 
return`` 
new`` 
ErrorDataResult`` &
<``& '
User``' +
>``+ ,
(``, -
user``- 1
)``1 2
;``2 3
}aa 	
publiccc 
IResultcc 
Insertcc 
(cc 
UserInsertDtocc +
userInsertDtocc, 9
)cc9 :
{dd 	
varff 
userff 
=ff 
_userRepositoryff &
.ff& '
Getff' *
(ff* +
xff+ ,
=>ff- /
xff0 1
.ff1 2
IdentityNumberff2 @
==ffA C
userInsertDtoffD Q
.ffQ R
IdentityNumberffR `
&&ffa c
xffd e
.ffe f
IsActivefff n
==ffo q
trueffr v
)ffv w
;ffw x
ifgg 
(gg 
usergg 
==gg 
nullgg 
)gg 
{hh 
_userRepositoryii 
.ii  
Insertii  &
(ii& '
newii' *
Userii+ /
{jj 
CreatedDatekk 
=kk  !
DateTimekk" *
.kk* +
Nowkk+ .
,kk. /
IsActivell 
=ll 
truell #
,ll# $
	Firstnamemm 
=mm 
userInsertDtomm  -
.mm- .
	Firstnamemm. 7
,mm7 8
Lastnamenn 
=nn 
userInsertDtonn ,
.nn, -
Lastnamenn- 5
,nn5 6
IdentityNumberoo "
=oo# $
userInsertDtooo% 2
.oo2 3
IdentityNumberoo3 A
,ooA B
Emailpp 
=pp 
userInsertDtopp )
.pp) *
Emailpp* /
,pp/ 0
Phoneqq 
=qq 
userInsertDtoqq )
.qq) *
Phoneqq* /
,qq/ 0
LicensePlaterr  
=rr! "
userInsertDtorr# 0
.rr0 1
LicensePlaterr1 =
,rr= >
IsManagementss  
=ss! "
userInsertDtoss# 0
.ss0 1
IsManagementss1 =
}tt 
)tt 
;tt 
returnuu 
newuu 
SuccessResultuu (
(uu( )
$struu) A
)uuA B
;uuB C
}vv 
returnww 
newww 
ErrorResultww "
(ww" #
)ww# $
;ww$ %
}xx 	
publiczz 
IResultzz 
Updatezz 
(zz 
UserInsertDtozz +
userInsertDtozz, 9
)zz9 :
{{{ 	
var|| 
user|| 
=|| 
_userRepository|| &
.||& '
Get||' *
(||* +
x||+ ,
=>||- /
x||0 1
.||1 2
Id||2 4
==||5 7
$num||8 9
&&||: <
x||= >
.||> ?
IsActive||? G
==||H J
true||K O
)||O P
;||P Q
if}} 
(}} 
user}} 
!=}} 
null}} 
)}} 
{~~ 
user 
. 
UpdatedDate  
=! "
DateTime# +
.+ ,
Now, /
;/ 0
user
€€ 
.
€€ 
	Firstname
€€ 
=
€€  
user
€€! %
.
€€% &
	Firstname
€€& /
!=
€€0 2
default
€€3 :
?
€€; <
userInsertDto
€€= J
.
€€J K
	Firstname
€€K T
:
€€U V
user
€€W [
.
€€[ \
	Firstname
€€\ e
;
€€e f
user
 
.
 
Lastname
 
=
 
user
  $
.
$ %
Lastname
% -
!=
. 0
default
1 8
?
9 :
userInsertDto
; H
.
H I
Lastname
I Q
:
R S
user
T X
.
X Y
Lastname
Y a
;
a b
user
‚‚ 
.
‚‚ 
IdentityNumber
‚‚ #
=
‚‚$ %
user
‚‚& *
.
‚‚* +
IdentityNumber
‚‚+ 9
!=
‚‚: <
default
‚‚= D
?
‚‚E F
userInsertDto
‚‚G T
.
‚‚T U
IdentityNumber
‚‚U c
:
‚‚d e
user
‚‚f j
.
‚‚j k
IdentityNumber
‚‚k y
;
‚‚y z
user
ƒƒ 
.
ƒƒ 
Email
ƒƒ 
=
ƒƒ 
user
ƒƒ !
.
ƒƒ! "
Email
ƒƒ" '
!=
ƒƒ( *
default
ƒƒ+ 2
?
ƒƒ3 4
userInsertDto
ƒƒ5 B
.
ƒƒB C
Email
ƒƒC H
:
ƒƒI J
user
ƒƒK O
.
ƒƒO P
Email
ƒƒP U
;
ƒƒU V
user
„„ 
.
„„ 
Phone
„„ 
=
„„ 
user
„„ !
.
„„! "
Phone
„„" '
!=
„„( *
default
„„+ 2
?
„„3 4
userInsertDto
„„5 B
.
„„B C
Phone
„„C H
:
„„I J
user
„„K O
.
„„O P
Phone
„„P U
;
„„U V
user
…… 
.
…… 
LicensePlate
…… !
=
……" #
user
……$ (
.
……( )
LicensePlate
……) 5
!=
……6 8
default
……9 @
?
……A B
userInsertDto
……C P
.
……P Q
LicensePlate
……Q ]
:
……^ _
user
……` d
.
……d e
LicensePlate
……e q
;
……q r
user
†† 
.
†† 
IsManagement
†† !
=
††" #
user
††$ (
.
††( )
IsManagement
††) 5
!=
††6 8
default
††9 @
?
††A B
userInsertDto
††C P
.
††P Q
IsManagement
††Q ]
:
††^ _
user
††` d
.
††d e
IsManagement
††e q
;
††q r
_userRepository
‡‡ 
.
‡‡  
Update
‡‡  &
(
‡‡& '
user
‡‡' +
)
‡‡+ ,
;
‡‡, -
return
ˆˆ 
new
ˆˆ 
SuccessResult
ˆˆ (
(
ˆˆ( )
$str
ˆˆ) F
)
ˆˆF G
;
ˆˆG H
}
‰‰ 
return
ŠŠ 
new
ŠŠ 
ErrorResult
ŠŠ "
(
ŠŠ" #
)
ŠŠ# $
;
ŠŠ$ %
}
‹‹ 	
}
ŒŒ 
} 