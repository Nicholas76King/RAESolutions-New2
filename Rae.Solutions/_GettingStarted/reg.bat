set reg=regsvr32 
set rs=c:\code\rae\solutions\main\rae.solutions\
set ref=%rs%myreferences\

REM set sys=c:\windows\system32\
REM copy %ref%chillyraes.dll %sys%chillyraes.dll
REM copy %ref%dforrt.dll %sys%dforrt.dll
REM copy %ref%raedll_condensing_unit.dll %rs%raedll_condensing_unit.dll
REM %reg%%rs%raedll_condensing_unit.dll
REM %reg%%ref%rae_user_logging.dll

%reg%%ref%rae_selectionrating.dll
%reg%%ref%raecoilweightdll.dll
%reg%%ref%raedll_coil_pricing.dll