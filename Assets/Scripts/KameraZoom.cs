using UnityEngine;

namespace KameraKontrol {
	public class KameraZoom : MonoBehaviour {
		[SerializeField] private float hiz = 25f;         // Yakınlaşma hızı
		[SerializeField] private float yumusatma = 5f;   // Yakınlaşma yumuşatma hızı
		[SerializeField] private Vector2 menzil = new Vector2(30f, 70f);  // Yakınlaşma menzili
		[SerializeField] private Transform kameraTutucu;  // Kamera tutucusu transformu

		private Vector3 kameraYon => transform.InverseTransformDirection(kameraTutucu.forward);  // Kameranın ileri yönünü yerel uzayda alır

		private Vector3 hedefPozisyon;  // Hedef pozisyon
		private float _input;           // Fare tekerleği girişi

		private void Awake() {
			hedefPozisyon = kameraTutucu.localPosition;  // Hedef pozisyonu başlangıçta kamera tutucusunun yerel pozisyonuna ayarla
		}

		private void HandleInput() {
			_input = Input.GetAxisRaw("Mouse ScrollWheel");  // Fare tekerleği girişini al
		}

		private void Zoom() {
			Vector3 sonrakiHedefPozisyon = hedefPozisyon + kameraYon * (_input * hiz);  // Yakınlaşma miktarına göre yeni hedef pozisyonunu hesapla
			if (IsInBounds(sonrakiHedefPozisyon)) hedefPozisyon = sonrakiHedefPozisyon;  // Eğer yeni pozisyon belirtilen menzil içinde ise hedef pozisyonu güncelle
			kameraTutucu.localPosition = Vector3.Lerp(kameraTutucu.localPosition, hedefPozisyon, Time.deltaTime * yumusatma);  // Kamera tutucusunun pozisyonunu yumuşak bir geçiş ile hedef pozisyona yaklaştır
		}

		private bool IsInBounds(Vector3 position) {
			return position.magnitude > menzil.x && position.magnitude < menzil.y;  // Pozisyonun belirtilen menzilin içinde olup olmadığını kontrol et
		}

		private void Update() {
			HandleInput();  // Kullanıcı girişini işle
			Zoom();         // Yakınlaşma işlemini gerçekleştir
		}
	}
}
