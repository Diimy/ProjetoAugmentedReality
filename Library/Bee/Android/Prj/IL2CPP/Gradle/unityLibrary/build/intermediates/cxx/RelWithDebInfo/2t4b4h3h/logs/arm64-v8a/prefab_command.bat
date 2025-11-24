@echo off
"C:\\Program Files\\Unity\\Hub\\Editor\\6000.3.0b10\\Editor\\Data\\PlaybackEngines\\AndroidPlayer\\OpenJDK\\bin\\java" ^
  --class-path ^
  "C:\\Users\\dimit\\.gradle\\caches\\modules-2\\files-2.1\\com.google.prefab\\cli\\2.1.0\\aa32fec809c44fa531f01dcfb739b5b3304d3050\\cli-2.1.0-all.jar" ^
  com.google.prefab.cli.AppKt ^
  --build-system ^
  cmake ^
  --platform ^
  android ^
  --abi ^
  arm64-v8a ^
  --os-version ^
  29 ^
  --stl ^
  c++_shared ^
  --ndk-version ^
  27 ^
  --output ^
  "C:\\Users\\dimit\\AppData\\Local\\Temp\\agp-prefab-staging5383530186791526871\\staged-cli-output" ^
  "C:\\Users\\dimit\\.gradle\\caches\\8.13\\transforms\\1e7cc65d4e74b23bd94dca9ec0ac2eb3\\transformed\\jetified-games-activity-3.0.5\\prefab"
