using System;
using ServiceLocator.Events;
using ServiceLocator.Map;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Utilities;
using ServiceLocator.Wave;
using UnityEngine;

namespace Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        public PlayerService PlayerService { get; private set; }
        public SoundService SoundService { get; private set; }
        public WaveService WaveService { get; private set; }
        public MapService MapService { get; private set; }
        public EventService EventService { get; private set; }
        [SerializeField]private UIService uiService;
        public UIService UIService => uiService;
        [Header("Player Service data")]
        [SerializeField]private PlayerScriptableObject playerScriptableObject;
        [Header("Sound Service data")]
        [SerializeField] private SoundScriptableObject soundScriptableObject;
        [SerializeField] private AudioSource audioEffects;
        [SerializeField] private AudioSource backgroundMusic;
        [Header("Wave Service data")]
        [SerializeField] private WaveScriptableObject waveScriptableObject;
        [Header("Map Service data")]
        [SerializeField] private MapScriptableObject mapScriptableObject;
        

        private void Start()
        {
            EventService = new EventService();
            PlayerService = new PlayerService(playerScriptableObject);
            WaveService = new WaveService(waveScriptableObject);
            MapService = new MapService(mapScriptableObject);
            SoundService = new SoundService( soundScriptableObject, audioEffects, backgroundMusic);
        }

        private void Update()
        {
            PlayerService.Update();
        }
    }
}
