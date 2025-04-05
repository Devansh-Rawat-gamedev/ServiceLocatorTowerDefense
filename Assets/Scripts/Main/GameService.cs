using System;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Utilities;
using UnityEngine;

namespace Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        public PlayerService PlayerService { get; private set; }
        public SoundService SoundService { get; private set; }
        [SerializeField]private UIService uiService;
        public UIService UIService => uiService;
        [Header("Player Service data")]
        [SerializeField]private PlayerScriptableObject playerScriptableObject;
        [Header("Sound Service data")]
        [SerializeField] private SoundScriptableObject soundScriptableObject;
        [SerializeField] private AudioSource audioEffects;
        [SerializeField] private AudioSource backgroundMusic;
        

        private void Start()
        {
            PlayerService = new PlayerService(playerScriptableObject);
            SoundService = new SoundService( soundScriptableObject, audioEffects, backgroundMusic);
        }

        private void Update()
        {
            PlayerService.Update();
        }
    }
}
