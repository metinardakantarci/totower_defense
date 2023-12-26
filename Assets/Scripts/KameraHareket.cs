using UnityEngine;

namespace KameraKontrol {
	public class KameraHareket : MonoBehaviour {
		[SerializeField] private float hiz = 1f;          // Kameranın hareket hızı
		[SerializeField] private float yumusatma = 5f;    // Kameranın yumuşak geçiş hızı
		[SerializeField] private Vector2 menzil = new (100, 100); // Kameranın hareket edebileceği sınırlar

		private Vector3 _targetPosition;    // Kameranın hedef konumu
		private Vector3 _input;             // Kullanıcı girişi

		private void Awake() {
			_targetPosition = transform.position; // Hedef konumu başlangıçta kameranın mevcut konumu olarak ayarla
		}
			
		private void HandleInput() {
			float x = Input.GetAxisRaw("Horizontal");   // Yatay (X) eksenindeki kullanıcı girişini al
			float z = Input.GetAxisRaw("Vertical");     // Dikey (Z) eksenindeki kullanıcı girişini al

			Vector3 right = transform.right * x;        // Hareket yönünü sağa (x ekseninde) çevir
			Vector3 forward = transform.forward * z;    // Hareket yönünü ileri (z ekseninde) çevir

			_input = (forward + right).normalized;       // Toplam hareket yönünü normalize et ve kaydet
		}

		private void Move() {
			Vector3 nextTargetPosition = _targetPosition + _input * hiz;  // Hedef konumunu güncelle
			if (IsInBounds(nextTargetPosition)) _targetPosition = nextTargetPosition; // Eğer hedef konum sınırlar içinde ise güncelle
			transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * yumusatma); // Kamerayı yumuşak bir şekilde hedef konuma hareket ettir
		}

		private bool IsInBounds(Vector3 position) {
			return position.x > - menzil.x &&   // X ekseni sınırlar içinde mi kontrol et
				   position.x < menzil.x &&
				   position.z > -menzil.y &&   // Z ekseni sınırlar içinde mi kontrol et
				   position.z < menzil.y;
		}
		
		private void Update() {
			HandleInput();  // Kullanıcı girişini işle
			Move();         // Hareket et
		}
	}
}
