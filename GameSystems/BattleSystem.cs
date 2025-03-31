using SplashKitSDK;
using System;
using DragonBallGame.CharacterClass;

namespace DragonBallGame
{
    public class BattleSystem
    {
        private Random _random = new Random();
        private Character _player;
        private Character _villain;
        private BattleUI _battleUI;
        private MessageManager _messageManager;
        private VillainAI _villainAI;

        public BattleSystem(Window window)
        {
            _battleUI = new BattleUI(window, new ImageManager());
            _messageManager = new MessageManager();
            _villainAI = new VillainAI();
        }

        public (string, int) BattleState(Character player, string difficulty)
        {
            _player = player;
            _villain = GetVillainByDifficulty(difficulty);

            _messageManager.AddMessage($"Battle Started: {_player.Name} vs {_villain.Name} ({difficulty} Difficulty)");

            while (_player.Health > 0 && _villain.Health > 0 && !_battleUI.Window.CloseRequested)
            {
                SplashKit.ProcessEvents();

                // Escape to Menu by pressing E 
                if (SplashKit.KeyTyped(KeyCode.EKey))
                {
                    return ($"{_player.Name} has run away!", 0);
                }

                SplashKit.ClearScreen(Color.White);

                _battleUI.DrawBattleState(_player, _villain);
                _messageManager.DrawMessages();

                ExecuteTurn();

                SplashKit.RefreshScreen(60);
            }

            string battleResult;
            int reward = 0;

            if (_villain.Health <= 0)
            {
                battleResult = $"{_villain.Name} has been defeated!";
                reward = GetRewardByDifficulty(difficulty);
                _player.ResetHealth();
                _player.ResetEnergy();
            }
            else
            {
                battleResult = $"{_player.Name} has been defeated...";
                _player.ResetHealth();
                _player.ResetEnergy();
            }

            return (battleResult, reward);
        }

        private Character GetVillainByDifficulty(string difficulty)
        {
            return difficulty switch
            {
                "Easy" => CharacterFactory.CreateCharacter("Frieza"),
                "Medium" => CharacterFactory.CreateCharacter("Cell"),
                "Hard" => CharacterFactory.CreateCharacter("Buu"),
                "Extreme" => CharacterFactory.CreateCharacter("Black"),
                _ => CharacterFactory.CreateCharacter("Frieza")
            };
        }

        private void ExecuteTurn()
        {
            if (_player.Health > 0)
            {
                if (SplashKit.KeyTyped(KeyCode.BKey))
                {
                    HandlePlayerBlock();
                }
                else if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    HandlePlayerAttack();
                }
            }
        }

        private void HandlePlayerBlock()
        {
            _player.Block();
            _messageManager.AddMessage($"{_player.Name} is blocking.");
            _player.IncreaseEnergy(_random.Next(10, 30));

            RefreshBattleUIWithDelay();
            VillainTurn();
        }

        private void HandlePlayerAttack()
        {
            _player.StopBlocking();

            //if the energy bar is full -> special ability, if not then normal atk
            int damage = (_player.Energy == 100) ? _player.Power / 10 : _random.Next(20, _player.Power / 12);

            if (_player.Energy == 100)
            {
                _messageManager.AddMessage($"{_player.Name} used {_player.SpecialAbility} for {damage} damage!");
                _player.ResetEnergy();
            }
            else
            {
                _messageManager.AddMessage($"{_player.Name} attacks {_villain.Name} for {damage} damage.");
                _player.IncreaseEnergy(_random.Next(10, 30));
            }

            if (_villain.IsBlocking)
            {
                damage /= 2;
                _messageManager.AddMessage($"{_villain.Name} blocked and reduced the damage by half!");
            }

            _villain.Health -= damage;
            _villain.Health = Math.Max(_villain.Health, 0);

            RefreshBattleUIWithDelay();
            _villain.StopBlocking();
            VillainTurn();
        }

        private void VillainTurn()
        {
            if (_villain.Health > 0)
            {
                VillainAction action = _villainAI.Action(_villain, _player);

                if (action == VillainAction.Block)
                {
                    _villain.Block();
                    _messageManager.AddMessage($"{_villain.Name} is blocking.");
                    _villain.IncreaseEnergy(_random.Next(10, 30));
                }
                else if (action == VillainAction.Attack)
                {
                    HandleVillainAttack();
                }

                RefreshBattleUIWithDelay();
                _player.StopBlocking();
            }
        }

        private void HandleVillainAttack()
        {
            int damage = (_villain.Energy == 100) ? _villain.Power / 10 : _random.Next(20, _villain.Power / 12);

            if (_villain.Energy == 100)
            {
                _messageManager.AddMessage($"{_villain.Name} used {_villain.SpecialAbility} for {damage} damage!");
                _villain.ResetEnergy();
            }
            else
            {
                _messageManager.AddMessage($"{_villain.Name} attacks {_player.Name} for {damage} damage.");
                _villain.IncreaseEnergy(_random.Next(10, 30));
            }

            if (_player.IsBlocking)
            {
                damage /= 2;
                _messageManager.AddMessage($"{_player.Name} blocked and reduced the damage by half!");
            }

            _player.Health -= damage;
            _player.Health = Math.Max(_player.Health, 0);
        }

        private void RefreshBattleUIWithDelay()
        {
            //update the battle UI
            SplashKit.ClearScreen(Color.White);
            _battleUI.DrawBattleState(_player, _villain);
            _messageManager.DrawMessages();
            SplashKit.RefreshScreen(60);
            System.Threading.Thread.Sleep(500);
        }

        private int GetRewardByDifficulty(string difficulty)
        {
            return difficulty switch
            {
                "Easy" => 100,
                "Medium" => 300,
                "Hard" => 500,
                "Extreme" => 1000,
                _ => 0
            };
        }
    }
}