using System.Collections;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Sample
{
    [TestFixture]
    public sealed class CharacterTests
    {
        private GameObject character;

        [UnitySetUp]
        public IEnumerator SetUp()
        {
            AsyncOperation operation = EditorSceneManager.LoadSceneAsyncInPlayMode(
                "Assets/Tests/Scenes/CharacterTests.unity",
                new LoadSceneParameters(LoadSceneMode.Single)
            );
            
            while (!operation.isDone)
            {
                yield return null;
            }

            this.character = GameObject.FindGameObjectWithTag("Player");
        }

        [UnityTest]
        public IEnumerator DamageTest()
        {
            //Arange:
            HealthComponent healthComponent = this.character.GetComponent<HealthComponent>();
            healthComponent.Health = 10;

            //Act:
            healthComponent.TakeDamage(5);

            //Assert:
            Assert.AreEqual(5, healthComponent.Health);
            yield break;
        }

        [UnityTest]
        public IEnumerator RestoreHealthTest()
        {
            //Arange:
            HealthComponent healthComponent = this.character.GetComponent<HealthComponent>();
            healthComponent.MaxHealth = 10;
            healthComponent.Health = 0;

            //Act:
            healthComponent.RestoreHitPoints(5);

            //Assert:
            Assert.AreEqual(5, healthComponent.Health);

            //Act:
            healthComponent.RestoreHitPoints(20);

            //Assert:
            Assert.AreEqual(10, healthComponent.Health);
            yield break;
        }

        [UnityTest]
        public IEnumerator DeathTest()
        {
            //Arange:
            HealthComponent healthComponent = this.character.GetComponent<HealthComponent>();
            healthComponent.Health = 10;

            //Act:
            healthComponent.TakeDamage(15);

            //Assert:
            Assert.AreEqual(0, healthComponent.Health);
            yield break;
        }

        [UnityTest]
        public IEnumerator MoveForwardTest()
        {
            //Arange:
            Transform transform = this.character.transform;
            transform.position = Vector3.zero;

            const float moveSpeed = 5;
            const float moveFrames = 100;
            
            //Act:
            MoveComponent moveComponent = this.character.GetComponent<MoveComponent>();
            moveComponent.MoveSpeed = moveSpeed;
            moveComponent.MoveDirection = Vector3.forward;

            for (int i = 0; i < moveFrames; i++)
            {
                yield return new WaitForFixedUpdate();
            }
            
            //Assert:
            Vector3 diff = transform.position - new Vector3(0, 0, moveSpeed * moveFrames * Time.fixedDeltaTime);
            Assert.AreEqual(0, diff.magnitude, 1e-2);
        }


        [UnityTest]
        public IEnumerator MoveDiagonalTest()
        {
            //Arange:
            Transform transform = this.character.transform;
            transform.position = Vector3.zero;

            const float moveSpeed = 5;
            const float moveFrames = 100;
            
            //Act:
            MoveComponent moveComponent = this.character.GetComponent<MoveComponent>();
            moveComponent.MoveSpeed = moveSpeed;
            moveComponent.MoveDirection = new Vector3(-1, 0, -1);

            for (int i = 0; i < moveFrames; i++)
            {
                yield return new WaitForFixedUpdate();
            }

            //Assert:
            float end = -moveSpeed * moveFrames * Time.fixedDeltaTime;
            Vector3 diff = transform.position - new Vector3(end, 0, end);
            Assert.AreEqual(0, diff.magnitude, 1e-2);
        }

        [UnityTest]
        public IEnumerator IntegrationTest()
        {
            //Arange:
            Transform transform = this.character.transform;
            transform.position = Vector3.zero;

            HealthComponent healthComponent = this.character.GetComponent<HealthComponent>();
            healthComponent.MaxHealth = 1;
            healthComponent.Health = 0;

            MoveComponent moveComponent = this.character.GetComponent<MoveComponent>();
            moveComponent.MoveSpeed = 5;
            moveComponent.MoveDirection = Vector3.forward;

            RotationComponent rotationComponent = this.character.GetComponent<RotationComponent>();
            rotationComponent.RotationSpeed = 5;
            rotationComponent.RotationDirection = Vector3.forward;

            //Act:
            yield return new WaitForSeconds(1.0f);

            //Assert:
            Assert.AreEqual(0.0f, transform.eulerAngles.y, 1);
            Assert.AreEqual(0.0f, transform.position.x, 1);
            Assert.AreEqual(0.0f, transform.position.z, 1);
        }
    }
}