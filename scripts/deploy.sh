dotnet publish
zip -r dist.zip bin/Debug/net/publish
scp dist.zip pinyin:~
ssh pinyin 'rm -Rf bin'
ssh pinyin 'unzip dist.zip'
ssh pinyin 'rm -Rf /var/www/pinyin-card-api/*'
ssh pinyin 'cp -R bin/Debug/net/publish/* /var/www/pinyin-card-api/'
ssh pinyin 'sudo supervisorctl restart pinyin-card-api'


