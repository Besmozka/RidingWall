Shader "Holes/Depth Mask" 
{
	SubShader 
	{
		// ������� ����� ������ ����� �������� ������� ������ ���������� � ����� (���,
		// ����-�������), �� ����� ���� � ������� �� ����� �������� ���� (����) 
		Tags { "Queue" = "Geometry-1" }
 
		// �� �������� ������� ������, ������ Z-�����
 		ColorMask 0
		ZWrite On
 
		// �� ����� ������� ������ �� ������ 
		Pass {}
	}
}