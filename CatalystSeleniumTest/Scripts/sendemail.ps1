
$currenttime = Get-Date -Format G

$appConfig = "C:\CatalystSeleniumTest\CatalystSeleniumTest.dll.config"

$tokens = [xml](Get-Content $appConfig)

$val = 'Catalyst Selenium tests ran with below configuration:<br>'

foreach ($token in $tokens.configuration.appSettings.add)
{
    if($token.key -eq "Password"){
        $val += "$($token.key) = XXXXXX <br>"
        }
    else{
        $val += "$($token.key) = $($token.value) <br>"
        }
}
$val += "__________________ <br>"

$file = "C:\CatalystSeleniumTest\TestResults\SeleniumTestResults.txt"

$tests_result = (Get-Content $file | Select-Object -last 12 | Select-Object -First 10) 

$tests_result |Foreach-Object{ $val += $_ + '<br>' }
   
$smtpServer = "mailhost.parago.com"
$att = new-object Net.Mail.Attachment($file)
$msg = new-object Net.Mail.MailMessage
$smtp = new-object Net.Mail.SmtpClient($smtpServer)
$smtp.Port = 25
$msg.From = "CatalystSeleniumTestResults@bhengagement.com"
#$msg.To.Add("rajesh.cheedalla@bhnetwork.com")
$msg.To.Add("DL-LewisvilleCatalystProductTest@bhnetwork.com")
$msg.To.Add("DL-LewisvilleCatalystProductDev@bhnetwork.com")

$msg.Subject = "Selenium Test results on " + $currenttime
$msg.IsBodyHtml = $true
$msg.Body = $val
$msg.Attachments.Add($att)
$smtp.Send($msg)
$att.Dispose()
 