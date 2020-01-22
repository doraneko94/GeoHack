# GeoHack
Codes for Geospatial Hackers Program 2019.<br>
Geospatial Hackers Program 2019のハンズオン動画で使用しているC#スクリプトです。<br>
こちらのコードをダウンロードして、ハンズオンに活用してください。

## PlayerController
Playerを操作するためのスクリプトです。<br>
public変数speedを外から変更できるため、Unityで実行中に移動・回転スピードが変えられます。

↑キー：前進<br>
↓キー：後退<br>
→キー：右回転<br>
←キー：左回転

の基本操作のほかに、転倒から復帰するための動きとして、

xキー：X軸方向回転<br>
zキー：Z軸方向回転

を追加しています。<br>
基本的には<br>
```
（移動方向） * speed * Time.deltaTime
```
で実装できますが、そこに適当な数字（10とか50とか）をかけることによって、詳細な速度設定を行っています。<br>
（適宜変更してみてください）

## EyeCameraScript
Cameraが特定のオブジェクトを追尾するためのスクリプトです。
```
public GameObject target
```
に追尾対象となるオブジェクトが入ります。<br>
スクリプト内ではnullが渡してあるので、Unityのインスペクタから、追尾させたいオブジェクトを選択してください。

基本的には、Updateごとに追尾対象のオブジェクトのpositionを取得し、そのY座標 +2, 進行方向（forward） -7 の位置にCameraを移動させることで追尾を実現しています。<br>
しかし、これだけだとオブジェクトの回転に合わせてCameraが回転しないので、
```
float arg_new = ArcTan(forward);
float arg_old = ArcTan(transform.forward);
transform.Rotate(0f, (arg_new - arg_old) % 360f, 0f);
```
でCameraを適切な角度に回転させています。<br>
Unityでは、rotationを直接変更することはできないため、transform.Rotate関数を用いる必要があります。<br>
そのために、arg_newでオブジェクトの回転角、arg_oldで現在のCameraの回転角を計算し、その差の分だけ回転させています。<br>
（360度以上回転するのは無駄なため、360で割った余りの分だけ回す）

ArctanはC#標準のMathf.Atanに基づくオリジナル関数です
```
float ArcTan(Vector3 forward)
{
    float f_x = forward.x;
    float f_z = forward.z;
    if (f_z == 0.0) {
        f_z += 1e-7f;
    }
    float arg = Mathf.Atan(f_x / f_z) / (2f * Mathf.PI) * 360f;

    if (f_z < 0 & f_x > 0) arg += 180f;
    if (f_z < 0 & f_x < 0) arg -= 180f;

    return arg;
}
```
オブジェクトまたはCameraの進行方向（forward）を受け取り、そのXとZの値から回転角を計算します。<br>
具体的には、横Z・縦Xの直角三角形を考え、その三角形の角度を求めます。<br>
この時、Mathf.Atanを用いれば、arctan(forward.x/forward.z)の値を取得することができます。<br>
（arctan(A)とは、tanθ=Aを満たすθの値を返す関数です）<br>
ここで、０で除算するのを避けるため、if文を挿入しています。

また、Mathf.Atanは
```
-π/2 < θ < π/2
```
の範囲でしか値を返さない（第１・４象限＝forward.zが正の時しか正当に評価されない）ので、forward.zが負の値をとる場合の調整を加え、またラジアンではなく度に変換し、
```
-180 < θ < 180 
```
の値が返るようにしています。
