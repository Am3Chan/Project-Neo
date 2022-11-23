#!/bin/bash
rm -rf "bin"

# ====================
# 
# ====================
dotnet publish "src/Neo/Neo.csproj" --no-self-contained --output "bin" --runtime linux-x64 \
  "-p:Configuration=Release" \
  "-p:DebugType=None" \
  "-p:GenerateRuntimeConfigurationFiles=true" \
  "-p:PublishSingleFile=true"

# ====================
# 
# ====================
cat > "bin/service-install.sh" << INSTALLER
#!/bin/bash
echo "================================================================================"
echo "このインストール スクリプトは、システム サービスを登録します。完了すると、このサ"
echo "ービスの名前はすべてのユーザーが読み取ることができます。検出目的で使用できないよ"
echo "うにするには、ランダムなサービス名を入力する必要があります。  まだ存在していない"
echo "ことを確認し、[0-9A-Z-] 内の文字のみを使用してください。"
echo "================================================================================"
read -p "サービス名: " serviceName

# ====================
# 
# ====================
rootPath=\$(realpath .)
execPath=\$(realpath "Neo")
servPath="/etc/systemd/system/\${serviceName}.service"

# ====================
# 
# ====================
cat > \$servPath << EOF
[Unit]
Description=\${serviceName}

[Service]
Type=simple
WorkingDirectory=\${rootPath}
ExecStart=\${execPath}

[Install]
WantedBy=multi-user.target
EOF

# ====================
# 
# ====================
chmod 770 "\$servPath"

# ====================
# 
# ====================
systemctl daemon-reload
systemctl start \${serviceName}
systemctl enable \${serviceName}
INSTALLER

cat > "bin/service-uninstall.sh" << UNINSTALLER
#!/bin/bash
read -p "サービス名: " serviceName

# ====================
#
# ====================
systemctl disable \${serviceName}
systemctl stop \${serviceName}

# ====================
#
# ====================
rm -rf "/etc/systemd/system/\${serviceName}.service"
UNINSTALLER

# ====================
#
# ====================
chmod +x "bin/service-install.sh"
chmod +x "bin/service-uninstall.sh"
