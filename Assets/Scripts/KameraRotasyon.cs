using UnityEngine;

namespace KameraKontrol {
	public class KameraRotasyon : MonoBehaviour {
		[SerializeField] private float hiz = 15f;        // Kameranın dönme hızı
		[SerializeField] private float yumusatma = 5f;  // Kameranın yumuşak geçiş hızı

		private float hedefAci;    // Hedef dönme açısı
		private float Aci;         // Mevcut dönme açısı

		private void Awake() {
			hedefAci = transform.eulerAngles.y;  // Hedef açıyı başlangıçta mevcut açı olarak ayarla
			Aci = hedefAci;
		}

		private void HandleInput() {
			if (!Input.GetMouseButton(1)) return;  // Fare sağ tuşuna basılmamışsa işlem yapma

			hedefAci += Input.GetAxisRaw("Mouse X") * hiz;  // Fare hareketine göre hedef açıyı güncelle
		}

		private void Rotate() {
			Aci = Mathf.Lerp(Aci, hedefAci, Time.deltaTime * yumusatma);  // Yumuşak geçiş ile mevcut açıyı hedef açıya yaklaştır
			transform.rotation = Quaternion.AngleAxis(hedefAci, Vector3.up);  // Kamerayı hedef açıya döndür
		}
	
		private void Update() {
			HandleInput();  // Kullanıcı girişini işle
			Rotate();       // Dönme işlemini gerçekleştir
		}
	}
}
