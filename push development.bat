@ECHO OFF

set /p m=Commit message:

git add * 

git commit -m "%m%"

git push origin development

echo finish

pause